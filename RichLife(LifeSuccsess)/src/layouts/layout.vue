<template>
  <div class="layout">
    <slot name="header"></slot>
   
    <div id="content">
      <slot/>
    </div>

    <slot name="footer">
      <layout-footer @getInTouch="$emit('getInTouch')" @onClick="showJoinModal" />
    </slot>
  </div>
</template>


<script lang="ts">
import Vue from "vue";
import { Component } from "vue-property-decorator";

import UserModel from "src/models/UserModel";
import cookie from "js-cookie"

@Component
export default class LayoutComponent extends Vue {
  
  showJoinModalFooter: boolean = false  // флаг на открытие формы join при клике на кнопку в layout-footer
  token: string  // token пользователя
  user: UserModel = null

  created() {
    window.scrollTo(0, 0)
    window.addEventListener('beforeunload', this.removeRefferalKeyCookie)
    // if (cookie.get('token') == '' || cookie.get('token') == undefined) {
    //   this.$router.push({ name: 'sign' })
    // }
  }

  removeRefferalKeyCookie() {
    cookie.remove('refferalKeyForRegister')
  }


  // checkUser() {
  //   if (this.$store.getters.returnUserStore) {
  //     this.user = this.$store.getters.returnUserStore
  //     this.token = this.$store.getters.returnUserStore.Token
  //   }

  //   console.log(this.token);
  //   console.log(this.user);
    

  //   if (!this.user || (this.user && (this.token == '' || this.token == undefined))) {
  //     this.$router.push({ name: 'sign' })
  //   } else {
  //     return
  //   }
  // }


  /**
   * Изменяем значение флага открытия формы join и передаем его значение на страницы, 
   * где используется данный компонент layout
   */
  showJoinModal() {
    this.showJoinModalFooter = true
    this.$emit('showJoinModalFooter', this.showJoinModalFooter)
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
  position: relative;
}

#content {
  /* padding: 40px 0; */
  width: 100%;
  flex: 1 1 auto;
}
</style>

