import Vue from "vue"

import './register-router-hooks'
import './register-components'
import './register-directives'
import app from './components/app.vue'
// import uiComponents from "ui-components";


import api from './api/dataSource/api/apiDataSource.plugin'
declare var ApiUrl:string //вебпак заменит на нужное значение при сборке
Vue.use(api,ApiUrl);


/**
 * Подключение хранилища Vuex
 */
import store from "./store/UserStore"

/**
 * Подключение плагинов
 */
import mainStore from './plugins/MainStore'
Vue.use(mainStore);

import domPlugin from './plugins/DomPlugin'
Vue.use(domPlugin);


/**
 * Подключение фильтров
 */

// import "./filters/routeStatus.ts"
import "./filters/moment.ts"
// import "./filters/transactionStatus.ts"


const moment = require('moment')
moment.locale('ru');
Vue.use(require('vue-moment'),{
    moment
});

// import { Component } from "vue-property-decorator";
// Component.registerHooks([
//     "beforeRouteEnter",
//     "beforeRouteLeave",
//     "beforeRouteUpdate",
// ])



import router from './router'






const v = new Vue({
    el: "#app",
    router: router,
    store: store,
    template: `<app/>`,
    components: { 
        app,
        // uiComponents  
    }
});




//console.dir(Vue)