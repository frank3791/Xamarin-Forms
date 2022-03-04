public class MyViewModel
{
    public ObservableCollection<string> items { get; set; } = new ObservableCollection<string>();


    public void LoadLandscapeData()
    {
        items.Clear();

        items.Add("power  slave");
        items.Add("staling   grad");
    }

    public void LoadPortraitData()
    {
        items.Clear();
        items.Add("powerslave");
        items.Add("stalinggrad");
    }

    public MyViewModel()
    {
        LoadPortraitData();
    }
}