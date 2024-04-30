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
    public class GetUserUpdateByIdQueryHandler: IRequestHandler<GetUserUpdateByIdQuery, UpdateUserRequestModel>
    {
        private readonly IUserService _userService;
        public GetUserUpdateByIdQueryHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<UpdateUserRequestModel> Handle(GetUserUpdateByIdQuery request, CancellationToken cancellationToken)
        {
            var result = await _userService.GetUserUpdateById(request.Id);
            return result;
        }
    }
}
