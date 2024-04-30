using Core_MVCMediatRApp.Entity;
using Core_MVCMediatRApp.ViewModels;
using MediatR;


namespace Application_MVCMediatRApp.UserProcessor.Commands
{
    public class DeleteUserCommand:IRequest<UserViewModel>
    {
        public int Id { get; set; }
        public DeleteUserCommand(int id)
        {
            Id = id;
        }
    }
}
