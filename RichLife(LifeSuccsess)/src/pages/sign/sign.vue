<template>
   <layout-clean > 

      <section class="section-sign">
         <sign-form @showGetMail="onShowGetEmail" @click="onShowJoinModal"></sign-form>
      </section>

      <!-- Форма регистрации -->
      <i-modal :contentMaxWidth="'600px'" :show="showJoinModal" @close="onHideJoinModal" >
         <join-form></join-form>
      </i-modal>

      <!-- Форма get email -->
      <i-modal :contentMaxWidth="'600px'" :show="showGetEmail" @close="onCloseGetEmail">
         <get-email></get-email>
      </i-modal>
   </layout-clean>
</template>  

<script lang="ts">
import Vue from "vue";
import { Component } from "vue-property-decorator"

@Component
export default class PageSignComponent extends Vue {

   showJoinModal: boolean = false  // флаг на открытие формы join
   showGetEmail: boolean = false  // флаг на открытие формы get email

   created() {
      let bodyOverflowHidden = document.querySelector('body')
      bodyOverflowHidden.classList.remove('hidden')
   }

   /**
    * Открытие модального окна с формой join
    */
   onShowJoinModal() {
      this.showJoinModal = true
      this.$emit('showJoin', this.showJoinModal)
   }

   /**
    * Закрытие модального окна с формой join
    */
   onHideJoinModal() {
      this.showJoinModal = false
   }

   /**
    * Открытие модалки формы get email
    */
   onShowGetEmail() {
      this.showGetEmail = true
      console.log(this.showGetEmail, 'showGetEmail');
      
   }

   /**
    * ЗАкрытие модалки формы get email
    */
   onCloseGetEmail() {
      this.showGetEmail = false
   }

}
</script>

<style scoped>

.section-sign {
   padding: 20px 15px;
   display: flex;
   align-items: center;
   justify-content: center;
   min-height: 100vh;
   width: 100%;
   background: url('/assets/img/backgrounds/bg2.webp') no-repeat center;
   background-size: cover;
   position: relative;
}

.section-sign::after {
   content: '';
   position: absolute;
   top: 0;
   left: 0;
   width: 100%;
   height: 100%;
   background: rgba(0, 0, 0, 0.4);
}

</style>