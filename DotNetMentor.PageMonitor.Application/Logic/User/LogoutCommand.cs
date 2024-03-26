﻿using DotNetMentor.PageMonitor.Application.Exceptions;
using DotNetMentor.PageMonitor.Application.Interfaces;
using DotNetMentor.PageMonitor.Application.Logic.Abstractions;
using DotNetMentor.PageMonitor.Domain.Entities;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetMentor.PageMonitor.Application.Logic.User
{
    public static class LogoutCommand
    {
        public class Request : IRequest<Result> 
        {

        }

        public class Result 
        {
        }

        public class Handler : BaseCommandHandler, IRequestHandler<Request, Result> 
        {
            private readonly IPasswordManager _passwordManager;
            public Handler(ICurrentAccountProvider currentAccountProvider, IApplicationDbContext applicationDbContext) :
                base(currentAccountProvider, applicationDbContext)
            {
                
            }

            public async Task<Result> Handle(Request request, CancellationToken cancellationToken) 
            {
                return new Result
                {

                };
            }


            public class Validator : AbstractValidator<Request> 
            {
                public Validator() 
                {

                }
            }
        }
    }
}
