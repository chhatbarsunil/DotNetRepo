using Core_MVCMediatRApp.ViewModels;
using MediatR;
using Service_MVCMediatRApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Application_MVCMediatRApp.UserProcessor.Commands
{
    public class UpdateUserCommandHandler:IRequestHandler<UpdateUserCommand,UpdateUserRequestModel>
    {
        private readonly IUserService _userService;

        public UpdateUserCommandHandler(IUserService userService)
        {
            _userService = userService;
        }
        public async Task<UpdateUserRequestModel> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var result = await _userService.UpdateUser(request.UpdateUserRequestModel);
            return result;
        }
    }
}
