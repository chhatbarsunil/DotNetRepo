using Core_MVCMediatRApp.ViewModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Application_MVCMediatRApp.UserProcessor.Commands
{
    public class UpdateUserCommand:IRequest<UpdateUserRequestModel>
    {
        public UpdateUserRequestModel UpdateUserRequestModel { get; set;} = new UpdateUserRequestModel();
        public UpdateUserCommand(UpdateUserRequestModel updateUserRequestModel)
        {
            UpdateUserRequestModel = updateUserRequestModel;
        }
    }
}
