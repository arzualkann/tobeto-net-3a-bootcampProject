using AutoMapper;
using Business.Abstracts;
using Business.Requests.BlackList;
using Business.Responses.Applications;
using Business.Responses.BlackList;
using Core.Utilities.Results;
using DataAccess.Abstracts;
using Entities.Concretes;
using Microsoft.EntityFrameworkCore;

namespace Business.Concretes;

public class BlackListManager : IBlackListService

{
    private readonly IBlackListRepository _blackListRepository;
    private readonly IMapper _mapper;

    public BlackListManager(IBlackListRepository blackListRepository, IMapper mapper)
    {
        _blackListRepository = blackListRepository;
        _mapper = mapper;
    }

    public async Task<IDataResult<CreateBlackListResponse>> AddAsync(CreateBlackListRequest request)
    {
        BlackList blackList  = _mapper.Map<BlackList>(request);

        await _blackListRepository.AddAsync(blackList);

        CreateBlackListResponse response = _mapper.Map<CreateBlackListResponse>(blackList);

        return new SuccessDataResult<CreateBlackListResponse>(response, "Added Successfully");
    }

    public async Task<IDataResult<DeleteBlackListResponse>> DeleteAsync(DeleteBlackListRequest request)
    {
        var blackList = await _blackListRepository.GetByIdAsync(predicate: blackList => blackList.Id == request.Id);

        if (blackList == null)
        {
            return new ErrorDataResult<DeleteBlackListResponse>("BlackList not found");
        }

        await _blackListRepository.DeleteAsync(blackList);

        var response = _mapper.Map<DeleteApplicationResponse>(blackList);

        return new SuccessDataResult<DeleteBlackListResponse>("BlackList not found");
    }

    public async Task<IDataResult<List<GetAllBlackListResponse>>> GetAllAsync()
    {
        List<BlackList> blackLists=await _blackListRepository.GetAllAsync();
        List<GetAllBlackListResponse> responses=_mapper.Map<List<GetAllBlackListResponse>>(blackLists);
        return new SuccessDataResult<List<GetAllBlackListResponse>>(responses, "Listed Succesfully");
    }

    public async Task<IDataResult<GetByIdBlackListResponse>> GetByIdAsync(int id)
    {
        var blackList=await _blackListRepository.GetByIdAsync(x=>x.Id==id);
        if (blackList == null)
        {
            return new ErrorDataResult<GetByIdBlackListResponse>("BlackList not found");
        }
        await _blackListRepository.DeleteAsync(blackList);
        var response=_mapper.Map<GetByIdBlackListResponse>(blackList);
        return new SuccessDataResult<GetByIdBlackListResponse>(response, "Showed successfully");

    }

    public async Task<IDataResult<UpdateBlackListResponse>> UpdateAsync(UpdateBlackListRequest request)
    {
        var blackList = await _blackListRepository.GetByIdAsync(predicate: blackList => blackList.Id == request.Id);
        if (blackList==null)
        {
            return new ErrorDataResult<UpdateBlackListResponse>("BlackList not found");
        }
        _mapper.Map(request, blackList);
        await _blackListRepository.UpdateAsync(blackList);
        var response = _mapper.Map<UpdateBlackListResponse>(blackList);
        return new SuccessDataResult<UpdateBlackListResponse>(response,"Updated successfully");
    }
}
