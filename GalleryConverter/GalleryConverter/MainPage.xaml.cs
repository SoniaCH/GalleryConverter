using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace GalleryConverter
{
    public partial class MainPage : ContentPage
    {
        #region the property
        protected bool SetProperty<T>(ref T backingStore, T value, [CallerMemberName]string propertyName = "", Action onChanged = null)
        {
            if (EqualityComparer<T>.Default.Equals(backingStore, value))
                return false;

            backingStore = value;
            onChanged?.Invoke();
            OnPropertyChanged(propertyName);
            return true;
        }
    

        bool isCheckedDog = false;
        public bool IsCheckedDog
        {
            get { return isCheckedDog; }
            set { SetProperty(ref isCheckedDog, value); }
        }
     

        bool isCheckedCat = false;
        public bool IsCheckedCat
        {
            get { return isCheckedCat; }
            set { SetProperty(ref isCheckedCat, value); }
        }

        bool isCheckedMonkey = false;
        public bool IsCheckedMonkey
        {
            get { return isCheckedMonkey; }
            set { SetProperty(ref isCheckedMonkey, value); }
        }

        bool isCheckedPanda = false;
        public bool IsCheckedPanda
        {
            get { return isCheckedPanda; }
            set { SetProperty(ref isCheckedPanda, value); }
        }

        bool isCheckedTiger = false;
        public bool IsCheckedTiger
        {
            get { return isCheckedTiger; }
            set { SetProperty(ref isCheckedTiger, value); }
        }
        #endregion

        public List<Animal> AnimalList;
        List<Animal> _item = new List<Animal>();



        #region methods tol load the list 

        public List<Animal> LoadTheListOfItems()
        {
            _item.Add(new Animal() { Id = "1", Img = "cat.jfif", Categorie = "Cats" });
            _item.Add(new Animal() { Id = "2", Img = "catone.jfif", Categorie = "Cats" });
            _item.Add(new Animal() { Id = "3", Img = "catthree.jpg", Categorie = "Cats" });
            _item.Add(new Animal() { Id = "4", Img = "cattwo.jpg", Categorie = "Cats" });
            _item.Add(new Animal() { Id = "5", Img = "dog.jfif", Categorie = "Dogs" });
            _item.Add(new Animal() { Id = "6", Img = "dogfour.jpg", Categorie = "Dogs" });
            _item.Add(new Animal() { Id = "7", Img = "dogone.jfif", Categorie = "Dogs" });
            _item.Add(new Animal() { Id = "8", Img = "dogthree.jpg", Categorie = "Dogs" });
            _item.Add(new Animal() { Id = "9", Img = "dogtwo.jpg", Categorie = "Dogs" });
            _item.Add(new Animal() { Id = "10", Img = "panda.jfif", Categorie = "Pandas" });
            _item.Add(new Animal() { Id = "11", Img = "tiger.jpg", Categorie = "Tigers" });


            return _item;
        }

        #endregion

        #region property to get the animals by category
        List<Animal> _dogs = new List<Animal>();
        List<Animal> _cats = new List<Animal>();
        List<Animal> _tigers = new List<Animal>();
        List<Animal> _pandas = new List<Animal>();
        int nbrDogs;
        int nbrCats;
        int nbrTigers;
        int nbrPandas;
        #endregion
        List<Animal> _selectedAnimals = new List<Animal>();
       
        int nbrAnimal;
        int nbrSelectedAnimals;

        public MainPage()
        {
            BindingContext = this;
            AnimalList = LoadTheListOfItems();
            InitializeComponent();
            AnimalImg.Source = "cat.jfif";
            nbrAnimal = AnimalList.Count();

        }  

        #region Passing from image to image: Gallery

        public ICommand TabTappedCommand
        {
            get
            {
                return new Command((e) =>
                {
                   
                    if (nbrSelectedAnimals>0)
                    {                                                                   
                        AnimalImg.Source = _selectedAnimals[nbrSelectedAnimals - 1].Img;
                        nbrSelectedAnimals = nbrSelectedAnimals - 1;
                        nbrAnimal = AnimalList.Count();
                        if (nbrSelectedAnimals == 0)
                        {
                            nbrSelectedAnimals = _selectedAnimals.Count();
                            AnimalImg.Source = _selectedAnimals[nbrSelectedAnimals - 1].Img;
                        }

                    }
                    if (IsCheckedTiger == false && IsCheckedDog == false && IsCheckedPanda == false && IsCheckedCat == false && nbrAnimal > 0)
                    {
                        AnimalImg.Source = AnimalList[nbrAnimal - 1].Img;
                        nbrAnimal = nbrAnimal - 1;
                        nbrDogs = _dogs.Count();
                        nbrCats = _cats.Count();
                        nbrPandas = _pandas.Count();
                        if (nbrAnimal == 0)
                        {
                            nbrAnimal = AnimalList.Count();
                            AnimalImg.Source = AnimalList[nbrAnimal - 1].Img;
                        }
                    }
                });
            }

        }
        #endregion

        #region Check and uncheck the chekbox
        public ICommand OnCheckDog
        {
            get
            {
                return new Command((e) =>
                {
                    if (IsCheckedDog == true)
                    {
                        foreach (Animal animal in AnimalList)
                        {
                            if (animal.Categorie == "Dogs")
                            {
                                _selectedAnimals.Remove(animal);
                                //AnimalImg.Source = animal.Img;
                            }
                        }
                        AnimalImg.Source = _selectedAnimals[0].Img;
                        IsCheckedDog = false;
                        nbrSelectedAnimals = _selectedAnimals.Count();
                    }
                    else {
                        IsCheckedDog = true;
                        AnimalImg.Source = "dog.jfif";
                        foreach (Animal animal in AnimalList)
                        {
                            if (animal.Categorie == "Dogs")
                            {
                                _selectedAnimals.Add(animal);
                               
                            }
                        }
                        nbrSelectedAnimals = _selectedAnimals.Count();
                    }
                    
                });
            }
        }

        public ICommand OnCheckCat
        {
            get
            {
                return new Command((e) =>
                {
                    if (IsCheckedCat == true)
                    {
                        foreach (Animal animal in AnimalList)
                        {
                            if (animal.Categorie == "Cats")
                            {
                                _selectedAnimals.Remove(animal);
                               
                            }
                        }
                        IsCheckedCat = false;
                        nbrSelectedAnimals = _selectedAnimals.Count();
                        AnimalImg.Source = _selectedAnimals[0].Img;
                    }
                    else
                    {
                        IsCheckedCat= true;
                        AnimalImg.Source = "cat.jfif";
                        foreach (Animal animal in AnimalList)
                        {
                            if (animal.Categorie == "Cats")
                            {
                                _selectedAnimals.Add(animal);

                            }
                        }
                        nbrSelectedAnimals = _selectedAnimals.Count();
                    }

                });
            }
        }

        public ICommand OnCheckTiger
        {
            get
            {
                return new Command((e) =>
                {
                    if (IsCheckedTiger == true)
                    {
                        foreach (Animal animal in AnimalList)
                        {
                            if (animal.Categorie == "Tigers")
                            {
                                _selectedAnimals.Remove(animal);

                            }
                        }
                        IsCheckedTiger = false;
                        AnimalImg.Source = _selectedAnimals[0].Img;
                        nbrSelectedAnimals = _selectedAnimals.Count();
                    }
                    else
                    {
                        IsCheckedTiger = true;
                        AnimalImg.Source = "tiger.jpg";
                        foreach (Animal animal in AnimalList)
                        {
                            if (animal.Categorie == "Tigers")
                            {
                                _selectedAnimals.Add(animal);

                            }
                        }
                        nbrSelectedAnimals = _selectedAnimals.Count();
                    }

                });
            }
        }

        public ICommand OnCheckPanda
        {
            get
            {
                return new Command((e) =>
                {
                    if (IsCheckedPanda == true)
                    {
                        foreach (Animal animal in AnimalList)
                        {
                            if (animal.Categorie == "Pandas")
                            {
                                _selectedAnimals.Remove(animal);

                            }
                        }
                        IsCheckedPanda = false;
                        AnimalImg.Source = _selectedAnimals[0].Img;
                        nbrSelectedAnimals = _selectedAnimals.Count();
                    }
                    else
                    {
                        IsCheckedPanda = true;
                        AnimalImg.Source = "panda.jfif";
                        foreach (Animal animal in AnimalList)
                        {
                            if (animal.Categorie == "Pandas")
                            {
                                _selectedAnimals.Add(animal);

                            }
                        }
                        nbrSelectedAnimals = _selectedAnimals.Count();

                    }

                });
            }
        }

        #endregion

    }
}
