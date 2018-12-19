/*import Vue from 'vue';
import Router from 'vue-router';

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
import ArticleEdit from './components/ArticleEdit';
import BookEdit from './components/BookEdit';
import ConferenceArticleEdit from './components/ConferenceArticleEdit';
import MonographEdit from './components/MonographEdit';
import PatentEdit from './components/PatentEdit';
import RaportEdit from './components/RaportEdit';
import NewTypePublication from './components/NewTypePublication';
import NewNotification from './components/NewNotification';





Vue.use(VueResource);
Vue.use(VueRouter);

 export const router = new VueRouter({
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
        { path: '/changePassword', component: ChangePassword },
        { path: '/userEdit', component: UserEdit },
        { path: '/article/:id/edit', component: ArticleEdit },
        { path: '/book/:id/edit', component: BookEdit },
        { path: '/conference_article/:id/edit', component: ConferenceArticleEdit },
        { path: '/monograph/:id/edit', component: MonographEdit },
        { path: '/raport/:id/edit', component: RaportEdit },
        { path: '/patent/:id/edit', component: PatentEdit },
        { path: '/publicationType/new', component: NewTypePublication },
        { path: '/notification/new', component: NewNotification }



    ]


})

router.beforeEach((to, from, next) => {
    // redirect to login page if not logged in and trying to access a restricted page
    const publicPages = ['/login'];
    const authRequired = !publicPages.includes(to.path);
    const loggedIn = localStorage.getItem('user');

    if (authRequired && !loggedIn) {
        return next('/login');
    }

    next();
})*/