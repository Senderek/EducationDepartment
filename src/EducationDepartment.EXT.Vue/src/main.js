import Vue from 'vue';
import App from './App.vue';
import VueRouter from 'vue-router';
import VueResource from 'vue-resource';
import Publications from './components/Publications';
import Article from './components/Article';
import Book from './components/Book';
import ConferenceArticle from './components/ConferenceArticle';
import PartOfBook from './components/PartOfBook';
import Patent from './components/Patent';
import Raport from './components/Raport';
import SignIn from './components/SignIn';
import SignUp from './components/SignUp';
import ChangePassword from './components/ChangePassword';
import UserEdit from './components/UserEdit';
 


Vue.use(VueResource);
Vue.use(VueRouter);

const router = new VueRouter({
    mode: 'history',
    base: __dirname,
    routes: [
        { path: '/', component: Publications },
        { path: '/article/new', component: Article },
        { path: '/book/new', component: Book },
        { path: '/conferenceArticle/new', component: ConferenceArticle },
        { path: '/partOfBook/new', component: PartOfBook },
        { path: '/patent/new', component: Patent },
        { path: '/raport/new', component: Raport },
        { path: '/signIn', component: SignIn },
        { path: '/signUp', component: SignUp },
        { path: '/changePassword', component: ChangePassword },
        { path: '/userEdit', component: UserEdit }
 
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
          
      
          
              <router-link to="/book/new" class="dropdown-item">Ksiazka</router-link>
              <router-link to="/partOfBook/new" class="dropdown-item">Czesc ksiazki</router-link>
              <router-link to="/article/new" class="dropdown-item">Artyku³</router-link>
              <router-link to="/conferenceArticle/new" class="dropdown-item">Material konferencyjny</router-link>
              <router-link to="/raport/new" class="dropdown-item">Raport</router-link>
              <router-link to="/patent/new" class="dropdown-item">Patent</router-link>
           </div>
</div>
           
        </ul>
        <form class="form-inline my-2 my-lg-0">
      <router-link to="/SignIn">
        <button type="button" class="btn btn-primary mr-2">Zaloguj</button>
       </router-link>

        <router-link to="/SignUp">
        <button type="button" class="btn btn-primary mr-2">Zarejestruj</button>
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