namespace ASquaredRonWASM.Shared
{
    public partial class BackgroundFront
    {
        private CancellationTokenSource _tokenSource = new CancellationTokenSource();
        private CancellationToken _token;

        private List<(int count, bool animated)> _frontCells = new List<(int count, bool animated)>();
        private List<int> _frontActives = new List<int>();
        private int _frontVariant = 0;

        private Random _rand = new Random();

        protected override async Task OnInitializedAsync()
        {
            _frontCells = Enumerable.Range(0, 16).Select(sel => (sel, false)).ToList();
            _token = _tokenSource.Token;
            await Task.Delay(1000);
            AnimateFront(_token);
        }

        private async Task AnimateFront(CancellationToken ct)
        {
            while (!ct.IsCancellationRequested)
            {
                _frontActives = new List<int>();
                for (int i = 0; i < _rand.Next(3, 9); i++)
                {
                    _frontActives.Add(_rand.Next(1, 17));
                }
                _frontCells.ForEach(cell => cell.animated = false);
                _frontCells = _frontCells.Select(cell => _frontActives.Contains(cell.count) ? (cell.count, true) : (cell.count, false)).ToList();
                StateHasChanged();
                await Task.Delay(6000);
            }
        }
    }
}
