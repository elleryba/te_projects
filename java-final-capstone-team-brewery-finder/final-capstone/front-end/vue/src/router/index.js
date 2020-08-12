import Vue from 'vue'
import Router from 'vue-router'
import Home from '../views/Home.vue'
import Login from '../views/Login.vue'
import Logout from '../views/Logout.vue'
import Register from '../views/Register.vue'
import store from '../store/index'
//added this 
import AddBrewery from '../views/AddBrewery.vue'
import UpdateBrewery from '../views/UpdateBrewery.vue'
import BeerList from '../views/BeerList.vue'
import AddBeer from '../views/AddBeer.vue'
import DeleteBeer from '../views/DeleteBeer.vue'
import BeerReview from '../views/BeerReview.vue'
import ReviewList from '../views/ReviewList.vue'
import WorldBreweries from '../components/WorldBreweries.vue'
//end of added 
Vue.use(Router)

/**
 * The Vue Router is used to "direct" the browser to render a specific view component
 * inside of App.vue depending on the URL.
 *
 * It also is used to detect whether or not a route requires the user to have first authenticated.
 * If the user has not yet authenticated (and needs to) they are redirected to /login
 * If they have (or don't need to) they're allowed to go about their way.
 */

const router = new Router({
  mode: 'history',
  base: process.env.BASE_URL,
  routes: [

    // this route path is temporary for testing

    {
      path: '/',
      name: 'route',
      component: Login,
      meta: {
        requiresAuth: false
      }
    },

    {
      path: '/home',
      name: 'home',
      component: Home,
      meta: {
        requiresAuth: true // changed to false for testing 
      }
    },
    {
      path: "/login",
      name: "login",
      component: Login,
      meta: {
        requiresAuth: false
      }
    },
    {
      path: "/logout",
      name: "logout",
      component: Logout,
      meta: {
        requiresAuth: false
      }
    },
    {
      path: "/register",
      name: "register",
      component: Register,
      meta: {
        requiresAuth: false
}
    },

    {
        path: '/add',
        name: 'add',
        component: AddBrewery,
        beforeEnter: (to, from, next) => {
          if (store.state.user.authorities.some(e => e['name'] === 'ROLE_BREWER')) {
              next()
            }
            else {
              next(from)
            }
          },
        meta: {
          requiresAuth: true,
        }
      },
    { 
        path: '/update/:id',
        name: 'updateBrewery',
        component: UpdateBrewery,
        beforeEnter: (to, from, next) => {
          if (store.state.user.authorities.some(e => e['name'] === 'ROLE_BREWER')) {
              next()
            }
            else {
              next(from)
            }
          },
        meta:{
          requiresAuth: true,
        }
      },
      {
        path: '/beers/:name',
        name: 'beerList',
        component: BeerList,
        beforeEnter: (to, from, next) => {
          if (store.state.user.authorities.some(e => e['name'] === 'ROLE_BEERLOVER')
           || store.state.user.authorities.some(e => e['name'] === 'ROLE_BREWER')) {
          next()
          }
          else {
            next(from)
          }
          },
        meta: {
          requiresAuth: true
        }
      },
      {
        path: '/beers/:name/reviews',
        name: 'reviews',
        component: ReviewList,
        beforeEnter: (to, from, next) => {
          if (store.state.user.authorities.some(e => e['name'] === 'ROLE_BEERLOVER')
           || store.state.user.authorities.some(e => e['name'] === 'ROLE_BREWER')) {
          next()
          }
          else {
            next(from)
          }
          },
        meta: {
          requiresAuth: true,
        }
      },
      {
        path: '/beers',
        name: 'allBeerList',
        component: BeerList,
        beforeEnter: (to, from, next) => {
          if (store.state.user.authorities.some(e => e['name'] === 'ROLE_BEERLOVER')
           || store.state.user.authorities.some(e => e['name'] === 'ROLE_BREWER')) {
          next()
          }
          else {
            next(from)
          }
          },
        meta: {
          requiresAuth: true 
        }
      },
      {
      path: '/addbeer',
        name: 'addbeer',
        component: AddBeer,
        beforeEnter: (to, from, next) => {
          if (store.state.user.authorities.some(e => e['name'] === 'ROLE_BREWER')) {
          next()
          }
          else {
            next(from)
          }
          },
        meta:{
          requiresAuth: true,
        }
      },
      {
        path: '/delete',
        name: 'deletebeer',
        component: DeleteBeer,
        beforeEnter: (to, from, next) => {    // Before proceeding to path
          if (store.state.user.authorities.some(e => e['name'] === 'ROLE_BREWER')) {
          next()
          }
          else {
            next(from)
          }
          },
        meta:{
          requiresAuth: true,
        }
      },
      {
        path: '/beers/addreview',
        name: 'addreview',
        component: BeerReview,
        beforeEnter: (to, from, next) => {
          if (store.state.user.authorities.some(e => e['name'] === 'ROLE_BEERLOVER')){
          next()
          }
          else {
            next(from)
          }
          },
        meta: {
          requiresAuth: true,
        }
      },
      {
       path: '/worldbreweries',
       name: 'worldbreweries',
       component: WorldBreweries,
       beforeEnter: (to, from, next) => {
        if (store.state.user.authorities.some(e => e['name'] === 'ROLE_BEERLOVER')
         || store.state.user.authorities.some(e => e['name'] === 'ROLE_BREWER')) {
        next()
        }
        else {
          next(from)
        }
        },
       meta: {
        requiresAuth: true,
       }
       }
  ]
})

router.beforeEach((to, from, next) => {
  // Determine if the route requires Authentication
  const requiresAuth = to.matched.some(x => x.meta.requiresAuth);

  // If it does and they are not logged in, send the user to "/login"
  if (requiresAuth && store.state.token === '') {
    next("/login");
  }
    // Else let them go to their next destination
     else{
      next();
  }
});

export default router;
