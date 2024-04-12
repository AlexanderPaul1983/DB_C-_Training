namespace LabExercise.Web.Features.FlickFlack;

public class GetFlickFlackQueryRequest : IRequest<GetFlickFlackQueryResponse>
{
    public int Start { get; set; }
    public int End { get; set; }

    public bool GetFlickFlackQuery()
    {
        const int maxOfListElements = 100;
        const int minOfListElements = 0;

        if ((End <= maxOfListElements && Start > minOfListElements) && Start >= End)
        {
            return true;
        }
        else return false;


    }
}

public class GetFlickFlackQueryResponse
{
    public List<string> Elements { get; set; } = [];
    
    
}

public class GetFlickFlackQueryHandler : IRequestHandler<GetFlickFlackQueryRequest, GetFlickFlackQueryResponse>
{
    public Task<GetFlickFlackQueryResponse> Handle(GetFlickFlackQueryRequest request,
        CancellationToken cancellationToken)
    {
        // TODO: Implement FlickFlack Request checks
        
        
        var result = new GetFlickFlackQueryResponse();
        // TODO: Implement FlickFlack logic
        int number = 3;
        int number2 = 4;
        var start = request.Start;
        var end = request.End;
        while (request.GetFlickFlackQuery())
        {
            for (int i = start; i <= end; i++)
            {
                
            }
            
        }

        

        return Task.FromResult(result);
    }
}