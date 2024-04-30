using Core_MVCMediatRApp.ViewModels;
using MediatR;
using Service_MVCMediatRApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Application_MVCMediatRApp.UserProcessor.Queries
{
    public class GetUserByIdQueryHandler: IRequestHandler<GetUserByIdQuery, UserViewModel>
    {
        private readonly IUserService _userService;
        public GetUserByIdQueryHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<UserViewModel> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var result = await _userService.GetUserById(request.Id);
            return result;
        }
    }
}
