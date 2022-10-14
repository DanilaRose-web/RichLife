<template>
  <div class="layout">
    <slot name="header"></slot>
   
    <div id="content">
      <slot/>
    </div>

    <slot name="footer"></slot>
  </div>
</template>


<script lang="ts">
import Vue from "vue";
import { Component } from "vue-property-decorator";

import UserModel from "src/models/UserModel";
import cookie from "js-cookie"

@Component
export default class LayoutCleanComponent extends Vue {

  token: string  // token пользователя
  user: UserModel = null

  created() {
    window.scrollTo(0, 0)
    this.checkUser()

    window.addEventListener('beforeunload', this.removeRefferalKeyCookie)
  }

  removeRefferalKeyCookie() {
    cookie.remove('refferalKeyForRegister')
  }

  checkUser() {
    
    if (this.$store.getters.returnUserStore) {
      this.user = this.$store.getters.returnUserStore
      this.token = this.$store.getters.returnUserStore.Token
    }

    console.log(this.token);
    console.log(this.user);
    

    
  }
  
  getMoney() {
    console.log('getMoney');
    
  }

}
</script>



<style scoped>

.layout {
  display: flex;
  flex-direction: column;
  align-items: center;
  justify-content: space-between;
  width: 100%;
  height: 100%;
  position: relative;
}

#content {
  /* padding: 40px 0; */
  width: 100%;
  flex: 1 1 auto;
}
</style>

