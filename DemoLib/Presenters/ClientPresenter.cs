using DemoLib.Models;
using DemoLib.Views;
using System.Collections.Generic;

namespace DemoLib.Presenters
{
    public class ClientPresenter
    {
        private readonly IClientsModel model_;
        private readonly List<IClientView> views_ = new List<IClientView>();
        private bool filterHasOrders_ = false;
        private bool filterNoOrders_ = false;
        public ClientPresenter(IClientsModel model, List<IClientView> views)
        {
            model_ = model;
            views_ = views;

            List<Client> allClients = model_.ReadAllClients();

            if (views_.Count > 0)
            {
                for (int i = 0; i < allClients.Count; ++i)
                {
                    Client client = allClients[i];
                    views[i].ShowClientInfo(client);
                }
            }
        }

        public void RefreshClients()
        {
            List<Client> allClients = model_.ReadAllClients();

            if (views_.Count > 0)
            {
                for (int i = 0; i < allClients.Count && i < views_.Count; ++i)
                {
                    Client client = allClients[i];
                    views_[i].ShowClientInfo(client);
                }
            }
        }

        public void SearchClientsByPartialName(string searchText)
        {
            foreach (IClientView view in views_)
            {
                Client client = view.GetClientInfo();

                string clientNameToLower = client.Name.ToLower();
                string text = searchText.ToLower();

                if(clientNameToLower.Contains(text))
                {
                    view.ShowView();
                }
                else
                {
                    view.HideView();
                }
            }
        }

        /// Д.З. Реализация фильтрации по какому-либо полю клиента - сделано
        /// Применение фильтра по заказам
        public void ApplyOrdersFilter(bool hasOrders, bool noOrders)
        {
            filterHasOrders_ = hasOrders;
            filterNoOrders_ = noOrders;

            // Если обе галочки сняты - показываем всех
            if (!hasOrders && !noOrders)
            {
                ResetFilter();
                return;
            }

            ApplyFilterToViews(client =>
            {
                int orderCount = client.order.GetRecords().Count;
                bool hasOrdersCondition = hasOrders && orderCount > 0;
                bool noOrdersCondition = noOrders && orderCount == 0;

                return hasOrdersCondition || noOrdersCondition;
            });
        }

        /// Сброс фильтра - показываем всех клиентов
        public void ResetFilter()
        {
            filterHasOrders_ = false;
            filterNoOrders_ = false;

            foreach (IClientView view in views_)
            {
                view.ShowView();
            }
        }

        /// Универсальный метод применения фильтра к представлениям
        private void ApplyFilterToViews(System.Func<Client, bool> filterCondition)
        {
            foreach (IClientView view in views_)
            {
                Client client = view.GetClientInfo();
                if (filterCondition(client))
                {
                    view.ShowView();
                }
                else
                {
                    view.HideView();
                }
            }
        }

        public (bool hasOrders, bool noOrders) GetCurrentFilter()
        {
            return (filterHasOrders_, filterNoOrders_);
        }
        /// Задание на 5+++++++. Сортировка  по числу заказов!!!

    }
}
