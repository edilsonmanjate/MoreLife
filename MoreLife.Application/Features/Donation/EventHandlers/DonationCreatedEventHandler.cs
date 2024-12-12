using MediatR;
using MoreLife.Application.Repositories;
using MoreLife.core.Entities;
using MoreLife.core.Events;

namespace MoreLife.Application.Features.Donations.EventHandlers;

public class DonationCreatedEventHandler : INotificationHandler<DonationCreatedEvent>
{
    private readonly IBloodStockRepository _bloodStockRepository;
    private readonly IUnitOfWork _unitOfWork;

    public DonationCreatedEventHandler(IBloodStockRepository bloodStockRepository, IUnitOfWork unitOfWork)
    {
        _bloodStockRepository = bloodStockRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(DonationCreatedEvent notification, CancellationToken cancellationToken)
    {
        var donation = notification.Donation;
        var bloodStock = await _bloodStockRepository.GetByBloodType(donation.Donator.BloodType, donation.Donator.BloodRhFactor.ToString(), cancellationToken);

        if (bloodStock != null)
        {
            bloodStock.UpdateQuantity(bloodStock.Quantity + donation.Quantity);
            await _bloodStockRepository.Update(bloodStock);
            await _unitOfWork.Save(cancellationToken);
        }
        else
        {
            bloodStock = new BloodStock
            (
                Guid.NewGuid(),
                donation.Donator.BloodType,
                donation.Quantity,
                donation.Donator.BloodRhFactor.ToString()
            );
            await _bloodStockRepository.Create(bloodStock);
            await _unitOfWork.Save(cancellationToken);
        }
    }
}
