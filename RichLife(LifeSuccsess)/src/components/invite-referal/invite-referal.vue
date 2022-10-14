<template>
   <div class="invite-referal" :class="[inviteOnHighScreen ? 'highScreen' : '', alignCenter ? 'center' : '', allWidth ? 'allWidth' : '']">
      <div class="photo"><img src="/assets/img/user-menu/photo.webp" alt="Наталья Колесниченко"></div>

      <div class="info">
         <div class="invite" :style="setStyle()">
            <strong>Наталья К.</strong> <span>пригласила Вас в WellbeLife</span>
         </div>
         
         <!-- <div class="user-detail">
            <div class="email" :style="setStyle()">success329@gmail.com</div>
            <div class="phone" :style="setStyle()">+37377738336</div>
         </div> -->

         <i-button v-if="withButton" @onClick="$emit('onClick')" class="services-menu-btn" :margin="'5px 0 0 0'">Присоединиться</i-button>
      </div>
   </div>
</template>

<script lang="ts">

import Vue from "vue";
import { Component, Prop } from "vue-property-decorator"

@Component
export default class InviteReferalComponent extends Vue {
   @Prop({ type: Boolean, default: false }) inviteOnHighScreen: boolean  // отображение invite-referal при window width >= 1130px
   @Prop({ type: Boolean, default: false }) allWidth: boolean
   @Prop({ type: String, default: '#121B23' }) color: string  // меняем цвет текста на светлом фоне
   @Prop({ type: Boolean, default: true }) withButton: boolean  // убираем кнопку в форме join
   @Prop({ type: Boolean, default: false }) alignCenter: boolean  // центровка по вертикали контента в .invite-referal

   
   showUserMenu: boolean = false


   created() {
      this.onShowUserMenu()
   }

   mounted() {
      window.addEventListener('resize', this.onShowUserMenu)
   }

   destroyed() {
      window.removeEventListener('resize', this.onShowUserMenu)
   }

   /**
    * Убираем user-menu при window width <= 520px
    */
   onShowUserMenu() {
      let windowWidth = window.innerWidth
      if (windowWidth <= 520) 
         this.showUserMenu = true 
         else this.showUserMenu = false 
   }

   /**
    * Установка стилей, которые передаются через props
    */
   setStyle(): Object {
      return {
         color: this.color
      }
   }
}
</script>

<style scoped>

.invite-referal {
   padding: 5px 0;
   display: flex;
   align-items: flex-start;
   justify-content: center;
   flex: 1 1 auto;
   position: relative;
}

.invite-referal.center {
   margin-bottom: 30px;
   align-items: center;
}

.invite-referal.highScreen {
   margin: 30px 0;
}



/* photo */
.photo {
   margin-right: 20px;
   display: flex;
   align-items: center;
   justify-content: center;
   width: 70px;
   height: 70px;
   min-width: 70px;
   min-height: 70px;
   border-radius: 50%;
   cursor: pointer;
   overflow: hidden;
}

.photo img {
   max-width: 100%;
   height: auto;
}





/* info */
.info { 
   /* margin-bottom: 10px;  */
}

.invite {
   margin-bottom: 5px;
   font-size: 15px;
   font-weight: 500;
   line-height: 120%;
   color: #121B23;
   position: relative;
}

.invite strong {
   display: flex;
   font-weight: 700;
}




/* info-flex */
.user-detail {
   display: flex;
   align-items: center;
   flex-wrap: wrap;
}

.email, .phone {
   margin-bottom: 5px;
   font-size: 15px;
   font-weight: 500;
   color: #121B23;
}

.email {
   margin-right: 20px;
}




/* hidden-menu */
.hidden-menu {
   padding: 20px;
   position: absolute;
   top: 120%;
   right: 0;
   width: 100%;
   min-width: 250px;
   background: #F8F9FC;
   box-shadow: 0 0 42px rgba(0, 0, 0, 0.1);
   border-left: 3px solid #12be83;
   opacity: 0;
   visibility: hidden;
   transition: all 0.2s ease-out;
}

.invite-referal:hover .hidden-menu {
   top: 102%;
   opacity: 1;
   visibility: visible;
}

.hidden-menu .photo {
   margin-right: 10px;
   width: 50px;
   min-width: 50px;
   height: 50px;
   min-height: 50px;
}

.user-info {
   margin-bottom: 20px;
   display: flex;
   align-items: center;
}

.hidden-menu .email,
.hidden-menu .phone {
   font-weight: 600;
}

.hidden-menu .email,
.hidden-menu .phone,
.invite.mb {
   margin-bottom: 10px;
}

.hidden-menu .phone {
   margin-bottom: 25px;
}



/* max-width */
@media all and (max-width: 1140px) {
   .invite-referal.highScreen { display: none; }
   .invite-referal.allWidth { display: flex; }
}

/* @media all and (max-width: 520px) {
   .maxw520 { display: none; }
   .invite-referal { align-items: center; justify-content: flex-end; flex: none; }
} */

@media all and (max-width: 420px) {
   .invite-referal, .info { display: flex; flex-direction: column; align-items: center; }
   .photo { margin-right: 0; margin-bottom: 10px; }
   .invite { display: flex; flex-direction: column; align-items: center; text-align: center; margin-bottom: 10px; }
   .invite strong { display: inline-block; margin-bottom: 5px; }
   .user-detail { flex-direction: column; align-items: center; margin-bottom: 10px; }
   .user-detail .email { margin-right: 0; }
}


/* min-width / height */
@media all and (min-width: 1141px) {
   .invite-referal { display: none; }
   .invite-referal.allWidth { display: flex; }
   .invite-referal.highScreen { display: flex; }
}

</style>