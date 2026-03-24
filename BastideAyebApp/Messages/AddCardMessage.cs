using BastideAyebApp.Models;
using CommunityToolkit.Mvvm.Messaging.Messages;


namespace BastideAyebApp.Messages
{
    public class AddCardMessage : ValueChangedMessage<CardModels>
    {
        public AddCardMessage(CardModels card) : base(card) { }
    }
}