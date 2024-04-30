using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi_MVCMediateRApp.Services;
using WebApi_MVCMediateRApp.ViewModels;

namespace WebApi_MVCMediateRApp.Application.UserProcessor.Queries
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
