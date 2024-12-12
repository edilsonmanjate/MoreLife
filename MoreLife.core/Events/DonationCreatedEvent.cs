using MediatR;

using MoreLife.core.Entities;

namespace MoreLife.core.Events;

public class DonationCreatedEvent : INotification
{
    public Donation Donation { get; }

    public DonationCreatedEvent(Donation donation)
    {
        Donation = donation;
    }
}