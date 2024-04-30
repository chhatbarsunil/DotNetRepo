using Core_MVCMediatRApp.ViewModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Application_MVCMediatRApp.UserProcessor.Queries
{
    public class GetUserUpdateByIdQuery : IRequest<UpdateUserRequestModel>
    {
        public int Id { get; set; }
        public GetUserUpdateByIdQuery(int id) {
            Id = id;
        }
    }
    
}
