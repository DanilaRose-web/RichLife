import UserModel from "src/models/UserModel";
import Vue from "vue";
import Vuex from "vuex";

Vue.use(Vuex)

export const store = new Vuex.Store({
   state: {   // хранилище
      userStore: null,
   },


   mutations: {
      userStore(state, userStore) {
         state.userStore = userStore
      },
      
   },

   getters: {
      returnUserStore(state) {
         return state.userStore;
      }
   }
}) 

export default store