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

        List<Animal> _dogs = new List<Animal>();
        List<Animal> _cats = new List<Animal>();
        List<Animal> _tigers = new List<Animal>();
        List<Animal> _pandas = new List<Animal>();
        int nbrDogs;
        int nbrCats;
        int nbrTigers;
        int nbrPandas;
        int nbrAnimal;

        public MainPage()
        {
            BindingContext = this;
            AnimalList = LoadTheListOfItems();
            InitializeComponent();
            AnimalImg.Source = "cat.jfif";
            nbrAnimal = AnimalList.Count();
           
            foreach (Animal animal in AnimalList)
            {
                if (animal.Categorie == "Dogs")
                {
                    _dogs.Add(animal);
                    //AnimalImg.Source = animal.Img;
                }
            }
            nbrDogs = _dogs.Count();
            
            foreach (Animal animal in AnimalList)
            {
                if (animal.Categorie == "Cats")
                {
                    _cats.Add(animal);
                }
            }
            nbrCats = _cats.Count();
            
            foreach (Animal animal in AnimalList)
            {
                if (animal.Categorie == "Tigers")
                {
                    _tigers.Add(animal);
                }
            }
            nbrTigers = _tigers.Count();

            foreach (Animal animal in AnimalList)
            {
                if (animal.Categorie == "Pandas")
                {
                    _pandas.Add(animal);
                }
            }
            nbrPandas = _pandas.Count();
        }

        #region Passing from image to image: Gallery
       
        public ICommand TabTappedCommand
        {
            get
            {
                return new Command((e) =>
                {
                   
                    if (IsCheckedDog == true && nbrDogs>0)
                    {
                                                                    
                        AnimalImg.Source = _dogs[nbrDogs-1].Img;
                        nbrDogs = nbrDogs - 1;
                        nbrCats = _cats.Count();
                        nbrPandas = _pandas.Count();
                        nbrTigers = _tigers.Count();
                        nbrAnimal = AnimalList.Count();
                        if (nbrDogs==0)
                        {
                            nbrDogs = _dogs.Count();
                            AnimalImg.Source = _dogs[nbrDogs - 1].Img;
                        }

                    }
                    if (IsCheckedCat == true && nbrCats>0)
                    {
                        AnimalImg.Source = _cats[nbrCats-1].Img;
                        nbrCats = nbrCats - 1;
                        nbrDogs = _dogs.Count();
                        nbrPandas = _pandas.Count();
                        nbrTigers = _tigers.Count();
                        nbrAnimal = AnimalList.Count();
                        if (nbrCats == 0)
                        {
                            nbrCats = _cats.Count();
                            AnimalImg.Source = _cats[nbrCats - 1].Img;
                        }
                    }

                    if (IsCheckedPanda == true && nbrPandas>0)
                    {
                        AnimalImg.Source = _pandas[nbrPandas-1].Img;
                        nbrPandas = nbrPandas - 1;
                        nbrDogs = _dogs.Count();
                        nbrCats = _cats.Count();
                        nbrTigers = _tigers.Count();
                        nbrAnimal = AnimalList.Count();
                        if (nbrPandas==0)
                        {
                            nbrPandas = _pandas.Count();
                            AnimalImg.Source = _pandas[nbrPandas - 1].Img;
                        }
                    }

                    if (IsCheckedTiger == true && nbrTigers>0)
                    {
                        AnimalImg.Source = _pandas[nbrTigers-1].Img;
                        nbrTigers = nbrTigers - 1;
                        nbrDogs = _dogs.Count();
                        nbrCats = _cats.Count();
                        nbrPandas = _pandas.Count();
                        nbrAnimal = AnimalList.Count();
                        if (nbrTigers == 0)
                        {
                            nbrTigers = _tigers.Count();
                            AnimalImg.Source = _pandas[nbrTigers - 1].Img;
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
                            AnimalImg.Source = _pandas[nbrAnimal - 1].Img;
                        }
                    }


                });
            }

        }
        #endregion

        #region Check and uncheck the chekbox
        public ICommand OnCheck
        {
            get
            {
                return new Command((e) =>
                {
                    if (int.Parse(e.ToString()) == 1)
                    {
                        IsCheckedDog = true;
                        IsCheckedCat = false;
                        IsCheckedTiger = false;
                        IsCheckedPanda = false;
                        AnimalImg.Source = "dog.jfif";
                    }
                    else if (int.Parse(e.ToString()) == 2)
                    {
                        IsCheckedDog = false;
                        IsCheckedCat = true;
                        IsCheckedTiger = false;
                        IsCheckedPanda = false;
                        AnimalImg.Source = "cat.jfif";
                    }
                    else if (int.Parse(e.ToString()) == 3)
                    {
                        IsCheckedCat = false;
                        IsCheckedDog = false;
                        IsCheckedTiger = false;
                        IsCheckedPanda = true;
                        AnimalImg.Source = "panda.jfif";
                    }
                    else if (int.Parse(e.ToString()) == 4)
                    {
                        IsCheckedCat = false;
                        IsCheckedDog = false;
                        IsCheckedTiger = true;
                        IsCheckedPanda = false;
                        AnimalImg.Source = "tiger.jpg";
                    }
                });
            }
        }
        #endregion

    }
}
