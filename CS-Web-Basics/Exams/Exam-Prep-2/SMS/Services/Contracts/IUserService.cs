using SMS.Models.FormModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Services.Contracts
{
    public interface IUserService
    {
        bool LoginUser(LoginFormModel loginForm);

        string RegisterUser(RegisterFormModel registerFormModel);
    }
}
