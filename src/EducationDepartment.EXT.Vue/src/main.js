import Vue from 'vue';
import App from './App.vue';
import VueRouter from 'vue-router';
import VueResource from 'vue-resource';
 

import Publications from './components/Publications';
import Article from './components/Article';
import Book from './components/Book';
import ConferenceArticle from './components/ConferenceArticle';
import Monograph from './components/Monograph';
import Patent from './components/Patent';
import Raport from './components/Raport';
import SignIn from './components/SignIn';
import SignUp from './components/SignUp';
import ChangePassword from './components/ChangePassword';
import UserEdit from './components/UserEdit';
import NewTypePublication from './components/NewTypePublication';
import NewNotification from './components/NewNotification';
import PublicationTypes from './components/PublicationTypes';
 
import TypeSelector from './components/TypeSelector';
import OtherTypesPublication from './components/OtherTypesPublication';
import Notifications from './components/Notifications';
import PublicationShow from './components/PublicationShow';
import PublicationTypesEdit from './components/PublicationTypesEdit';
import Example from './components/Example';


Vue.use(VueResource);
Vue.use(VueRouter);
Vue.http.headers.common['Access-Control-Allow-Origin'] = '*';
Vue.http.options.emulateJSON = true
Vue.http.options.emulateHTTP = true
Vue.http.options.crossOrigin = true

Vue.http.headers.common['Access-Control-Allow-Origin'] = '*'
Vue.http.headers.common['Content-Type'] = 'application/x-www-form-urlencoded'
Vue.http.headers.common['Accept'] = 'application/json, text/plain, */*'
Vue.http.headers.common['Access-Control-Allow-Headers'] = 'Origin, Accept, Content-Type, Authorization, Access-Control-Allow-Origin'

 const router = new VueRouter({
    mode: 'history',
    base: __dirname,
    routes: [
        { path: '/', component: Publications },
        { path: '/article/new', component: Article },
        { path: '/book/new', component: Book },
        { path: '/conferenceArticle/new', component: ConferenceArticle },
        { path: '/monograph/new', component: Monograph },
        { path: '/patent/new', component: Patent },
        { path: '/raport/new', component: Raport },
        { path: '/signIn', component: SignIn },
        { path: '/signUp', component: SignUp },
        { path: '/account/changePassword/:id', component: ChangePassword },
        { path: '/account/edit/:id', component: UserEdit },
        { path: '/publicationType/new', component: NewTypePublication },
        { path: '/notification/new', component: NewNotification }, 
        { path: '/publicationTypes', component: PublicationTypes },
        { path: '/typeSelector', component: TypeSelector },
        { path: '/otherTypesPublication', component: OtherTypesPublication },
        { path: '/ notifications', component: Notifications }, 
        { path: '/publications/:id', component: PublicationShow }, 
        { path: '/publicationTypes/edit/:id', component: PublicationTypesEdit },  
        { path: '/example/new', component: Example }  

    ]


})

 
new Vue({
    router,
    template: `<div id="app">
 
 

      <nav class="navbar navbar-expand-md navbar-dark bg-dark fixed-top">
      
        <router-link to="/">
        <button type="button" class="btn mr-2">Publikacje</button>
       </router-link>
        
      <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarsExampleDefault" aria-controls="navbarsExampleDefault" aria-expanded="false" aria-label="Toggle navigation">
        <span class="navbar-toggler-icon"></span>
      </button>

      <div class="collapse navbar-collapse" id="navbarsExampleDefault">
        <ul class="navbar-nav mr-auto">
         
                <div class="btn-group">
                <button type="button" class="btn btn-success dropdown-toggle" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                 Dodaj
                </button>
                <div class="dropdown-menu">
          
      
          
              <router-link to="/book/new" class="dropdown-item">Ksi&#x0105;&#x017C;ka</router-link>
              <router-link to="/monograph/new" class="dropdown-item">Monografia</router-link>
              <router-link to="/article/new" class="dropdown-item">Artyku&#x0142;</router-link>
              <router-link to="/conferenceArticle/new" class="dropdown-item">Materia&#x0142; konferencyjny</router-link>
              <router-link to="/raport/new" class="dropdown-item">Raport</router-link>
              <router-link to="/patent/new" class="dropdown-item">Patent</router-link>
              <router-link to="/typeSelector" class="dropdown-item">Inne</router-link>
           </div>


        <router-link to="/notification/new">
        <button type="button" class="btn btn-success ml-2">Nowe powiadomienie</button>
        </router-link>

        <router-link to="/publicationTypes">
        <button type="button" class="btn btn-success ml-2">Typy publikacji</button>
        </router-link>

       
</div>

        
           
        </ul>
        <form class="form-inline my-2 my-lg-0">
      <router-link to="/SignIn">
        <button type="button" class="btn btn-primary mr-2">Zaloguj</button>
       </router-link>

        <router-link to="/SignUp">
        <button type="button" class="btn btn-primary mr-2">Zarejestruj</button>
       </router-link>

     
        
        <router-link to="/account/edit/1">
        <button type="button" class="btn btn-primary mr-2">Edytuj dane</button>
       </router-link>
    


           
        </form>
      </div>
    </nav>

   <div style="margin: 20 px">

<main role="main" class="container">

      <div class="starter-template">
 <router-view></router-view>
      </div>

    </main><!-- /.container -->
           
           
 </div>
    
               </div>
`
}).$mount('#app') 
/*
 * router.beforeEach((to, from, next) => {
  // redirect to login page if not logged in and trying to access a restricted page
  const publicPages = ['/login'];
  const authRequired = !publicPages.includes(to.path);
  const loggedIn = localStorage.getItem('user');

  if (authRequired && !loggedIn) {
    return next('/login');
  }

  next();
})*/