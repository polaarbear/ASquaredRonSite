namespace ASquaredRonWASM.Shared
{
    public partial class BackgroundBack
    {
        private CancellationTokenSource _tokenSource = new CancellationTokenSource();
        private CancellationToken _token;

        private List<(int count, bool animated)> _backCells = new List<(int count, bool animated)>();
        private List<int> _backActives = new List<int>();
        private int _backVariant = 0;

        private Random _rand = new Random();

        protected override async Task OnInitializedAsync()
        {
            _backCells = Enumerable.Range(0, 4).Select(sel => (sel, false)).ToList();
            _token = _tokenSource.Token;
            AnimateBack(_token);
        }

        private async Task AnimateBack(CancellationToken ct)
        {
            while (!ct.IsCancellationRequested)
            {
                _backActives = new List<int>();
                for (int i = 0; i < _rand.Next(2, 3); i++)
                {
                    _backActives.Add(_rand.Next(1, 5));
                }
                _backCells.ForEach(cell => cell.animated = false);
                _backCells = _backCells.Select(cell => _backActives.Contains(cell.count) ? (cell.count, true) : (cell.count, false)).ToList();
                StateHasChanged();
                await Task.Delay(4000);
            }
        }
    }
}
