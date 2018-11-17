import Vue from 'vue';
import App from './App.vue';
import VueRouter from 'vue-router';
import VueResource from 'vue-resource';
import EducationDepartment from './components/EducationDepartment';
import Article from './components/Article';
import Book from './components/Book';
import ConferenceArticle from './components/ConferenceArticle';
import PartOfBook from './components/PartOfBook';
import Patent from './components/Patent';
import Raport from './components/Raport';
import SignIn from './components/SignIn';
import SignUp from './components/SignUp';   
 


Vue.use(VueResource);
Vue.use(VueRouter);

const router = new VueRouter({
    mode: 'history',
    base: __dirname,
    routes: [
        { path: '/', component: EducationDepartment },
        { path: '/article/new', component: Article },
        { path: '/book/new', component: Book },
        { path: '/conferenceArticle/new', component: ConferenceArticle },
        { path: '/partOfBook/new', component: PartOfBook },
        { path: '/patent/new', component: Patent },
        { path: '/raport/new', component: Raport },
        { path: '/signIn', component: SignIn },
        { path: '/signUp', component: SignUp }
 
    ]


})
 
new Vue({
    router,
    template: `<div id="app">
 
  <nav class="navbar navbar-dark fixed-top bg-dark flex-md-nowrap p-0 shadow">
      <a class="navbar-brand col-sm-3 col-md-2 mr-0" href="#">NOWA PUBLIKACJA</a>
        
        
      

      <ul class="navbar-nav px-3">
        <li class="nav-item text-nowrap">
          <router-link to="/signIn" class="nav-link">Zaloguj</router-link>
        </li>
      </ul>
 

    </nav>

<div class="container-fluid">
      <div class="row">
        <nav class="col-md-2 d-none d-md-block bg-light sidebar">
          <div class="sidebar-sticky">
            <ul class="nav flex-column">
                 
              <li class="nav-item">
               <router-link to="/book/new" class="nav-link">Ksiazka</router-link>
              </li>
              <li class="nav-item">
                <router-link to="/partOfBook/new" class="nav-link">Czesc ksiazki</router-link>
              </li>
              <li class="nav-item">
                
                
                  <router-link to="/article/new" class="nav-link">Artykul</router-link>
                
              </li>
              <li class="nav-item">
                
                   
                  <router-link to="/conferenceArticle/new" class="nav-link">Material konferencyjny</router-link>
                
              </li>
              <li class="nav-item">
                 
                  
                  <router-link to="/raport/new" class="nav-link">Raport</router-link>
                
              </li>
              <li class="nav-item">
               <router-link to="/patent/new" class="nav-link">Patent</router-link>
              </li>
</ul>
          </div>
        </nav>
<main role="main" class="col-md-9 ml-sm-auto col-lg-10 px-4">
          <div class="d-flex justify-content-between flex-wrap flex-md-nowrap align-items-center pt-3 pb-2 mb-3 border-bottom">
           <router-view></router-view>
           

          
</main>
</div>
       </div>
    
               </div>
`
}).$mount('#app') 