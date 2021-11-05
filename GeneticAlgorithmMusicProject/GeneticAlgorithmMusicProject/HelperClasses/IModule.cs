using System.Windows.Controls;

namespace GeneticAlgorithmMusicProject.HelperClasses
{
    public interface IModule
    {
        string Name { get; }
        UserControl UserInterface { get; }
        void Deactivate();
    }
}
