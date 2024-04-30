using Core_MVCMediatRApp.Entity;
using MediatR;
using WebApi_MVCMediateRApp.ViewModels;

namespace WebApi_MVCMediateRApp.Application.UserProcessor.Commands
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
