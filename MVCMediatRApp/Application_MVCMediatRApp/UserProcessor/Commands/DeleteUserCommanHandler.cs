using Core_MVCMediatRApp.ViewModels;
using MediatR;
using NuGet.Protocol.Plugins;
using Service_MVCMediatRApp.Services;

namespace Application_MVCMediatRApp.UserProcessor.Commands
{
    public class DeleteUserCommanHandler:IRequestHandler<DeleteUserCommand, UserViewModel>    {
        private readonly IUserService _userService;

        public DeleteUserCommanHandler(IUserService userService)
        {
            _userService = userService;
        }
        public async Task<UserViewModel> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var result = await _userService.DeleteUser(request.Id);
            return result;
        }
    }
}
