using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi_MVCMediateRApp.ViewModels;

namespace WebApi_MVCMediateRApp.Application.UserProcessor.Commands
{
    public class CreateUserCommand:IRequest<UserViewModel>
    {
        public CreateUserRequestModel createUserRequestModel { get; set; }
        public CreateUserCommand(CreateUserRequestModel createUserRequestModel)
        {
            this.createUserRequestModel = createUserRequestModel;
        }

    }
}
