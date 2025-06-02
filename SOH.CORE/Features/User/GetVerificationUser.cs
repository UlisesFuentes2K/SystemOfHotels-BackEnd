using MediatR;
using SOH.CORE.Dto;
using SOH.CORE.Interfaces;

namespace SOH.CORE.Features.User
{
    public class GetVerificationUser : IRequest<ValidarUser> 
    {
        public string Email { get; set; }
        public string PasswordHash { get; set; }
    }

    internal class GetVerificationUserCommon : IRequestHandler<GetVerificationUser, ValidarUser>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetVerificationUserCommon(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<ValidarUser> Handle(GetVerificationUser request, CancellationToken cancellationToken)
        {
            return await _unitOfWork.IUser.ValidarUserAsync(request.Email, request.PasswordHash);
        }
    }
}
