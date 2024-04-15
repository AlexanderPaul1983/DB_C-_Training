namespace LabExercise.Web.Features.FlickFlack;

public class GetFlickFlackQueryRequest : IRequest<GetFlickFlackQueryResponse>
{
    public int Start { get; set; }
    public int End { get; set; }

    public bool GetFlickFlackQuery()
    {
        const int maxOfListElements = 100;
        const int minOfListElements = 1;

        if (End > maxOfListElements || Start < minOfListElements || Start > End)
        {
            throw new ArgumentException("Ungültige Eingaben für Start und End.");
        }
        else
        {
            return true;
        }
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
        
        if (request.Start < 1)
        {
            throw new ArgumentException("Ungültige Eingabe, Start darf nicht weniger als 1 sein!");
        }
        else if (request.End > 100)
        {
            throw new ArgumentException("Falsche Eingabe: End darf nicht mehr als 100 sein!");
        }
        else if (request.End < request.Start)
        {
            throw new ArgumentException("Falsche Eingabe: Start darf nicht größer als End sein!");
        }
        
        
        var result = new GetFlickFlackQueryResponse();
            
        // TODO: Implement FlickFlack logic
        int number = 3;
        int number2 = 4;
        int number3 = number * number2;
        var start = request.Start;
        var end = request.End;
        
        if (request.GetFlickFlackQuery())
        {
            for (int i = start; i <= end; i++)
            {
                
                if (i % number3 == 0)
                {
                    result.Elements.Add("FlickFlack");
                }
                else if (i % number == 0)
                {
                    result.Elements.Add("Flick");
                }
                else if (i % number2 == 0)
                {
                    result.Elements.Add("Flack");
                }
                else
                {
                    
                     result.Elements.Add(i.ToString());
                }
                
            }
            
        }
        return Task.FromResult(result);
    }
    
}