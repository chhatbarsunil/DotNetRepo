using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi_MVCMediateRApp.ViewModels;

namespace WebApi_MVCMediateRApp.Application.UserProcessor.Commands
{
    public class UpdateUserCommand:IRequest<UserViewModel>
    {
        public UpdateUserRequestModel UpdateUserRequestModel { get; set;} = new UpdateUserRequestModel();
        public UpdateUserCommand(UpdateUserRequestModel updateUserRequestModel)
        {
            UpdateUserRequestModel = updateUserRequestModel;
        }
    }
}
