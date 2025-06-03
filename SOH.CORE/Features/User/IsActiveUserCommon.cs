using AutoMapper;
using MediatR;
using SOH.CORE.Interfaces;
using SOH.MAIN.Models.Users;

namespace SOH.CORE.Features.User
{
    public class IsActiveUserCommon : IRequest<bool>
    {
        public string Id { get; set; }
        public bool isActive { get; set; }
    }

    internal class IsActiveUserCommonHandler : IRequestHandler<IsActiveUserCommon, bool>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public IsActiveUserCommonHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<bool> Handle(IsActiveUserCommon request, CancellationToken cancellationToken)
        {
            return await _unitOfWork.IUser.IsActivoUserAsync(request.Id, request.isActive);
        }
    }
}
