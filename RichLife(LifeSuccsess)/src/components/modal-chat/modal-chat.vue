<template>
   <div class="modal-chat-wrap">
      <div class="icon" @click="openChat">
         <svg><use xlink:href="/assets/img/svg-sprite.svg#icon-chat"></use></svg>
      </div>

      <transition name="fadeChat">
         <div class="modal-chat" v-if="open">
            <div class="chat-header">
               <div class="flex">
                  <div class="photo">
                     <img src="/assets/img/user-menu/photo.webp" alt="">
                  </div>
                  <div class="name">WellbeLife</div>
               </div>

               <div class="i-close" @click="onClose">
                  <svg><use xlink:href="/assets/img/svg-sprite.svg#icon-close"></use></svg>
               </div>
            </div>

            <transition name="fadeChatContent" mode="out-in">
               <div class="chat-content" v-if="!showThanks" key="1">
                  <p class="chat-text">Задайте вопрос</p>
                  <p class="chat-text last"><strong>Мы перезвоним Вам как можно скорее</strong></p>

                  <chat-form @close="showThanks = true"></chat-form>
               </div>

               <div class="chat-content thanks" v-if="showThanks" key="2">
                  <p class="chat-text thanks">Ваш вопрос успешно отправлен нам</p>
                  <p class="chat-text"><strong>Мы свяжемся с Вами в ближайшее время</strong></p>
                  <p class="chat-text dancing">Спасибо! Хорошего дня и отличного настроения!</p>
               </div>
            </transition>

            <div class="chat-footer">
               <p>Пишите в любое время</p>
            </div>
         </div>
      </transition>
   </div>
</template>

<script lang="ts">
import Vue from "vue";
import { Component, Prop, Watch } from "vue-property-decorator"

@Component
export default class ModalChatComponent extends Vue {

   @Prop({ type: Boolean, default: false }) innerOpen: boolean

   @Watch('innerOpen') change() {
      this.open = this.innerOpen
   }

   open: boolean = false
   showThanks: boolean = false

   created() {
      this.open = this.innerOpen
   }

   onClose() {
      this.open = false,
      this.showThanks = false
      this.$emit('closeChat', this.open)
   }

   openChat() {
      this.open = true
   }

}
</script>

<style scoped>

.modal-chat-wrap {
   position: fixed;
   right: 20px;
   bottom: 20px;
   z-index: 2;
   max-width: 320px;
   width: 100%;
   display: flex;
   justify-content: flex-end;
   transition: all 0.3s ease-out;
}

.modal-chat-wrap p {
   user-select: none;
}

.icon {
   width: max-content;
}

.icon svg {
   width: 60px;
   height: 60px;
   fill: #ff5405;
   cursor: pointer;
   transition: all 0.2s ease-out;
}

.icon svg:hover {
   fill: #12be83;
}

/* modal-chat */
.modal-chat {
   border-radius: 15px;
   box-shadow: 0 0 20px rgba(0, 0, 0, 0.1);
   background: #F8F9FC;
   overflow: hidden;
   position: absolute;
   bottom: 0;
   opacity: 1;
   visibility: visible;
   right: 0;

}

.chat-header {
   padding: 10px 20px;
   /* background: #12be83; */
   /* border: 1px solid #e6e6eb; */
   display: flex;
   align-items: center;
   justify-content: space-between;
   box-shadow: 0 0 20px rgba(0, 0, 0, 0.1);
}

.chat-header .flex {
   display: flex;
   align-items: center;
}

.i-close {
   margin-left: 15px;
}

.i-close svg {
   width: 20px;
   height: 20px;
   fill: #12be83;
   cursor: pointer;
   transition: all 0.2s ease-out;
}

.i-close:hover svg {
   fill: #0da671;
}

.i-close:active svg {
   fill: #0da671;
   transform: scale(0.8);
}

.photo {
   margin-right: 15px;
   width: 40px;
   min-width: 40px;
   height: 40px;
   min-height: 40px;
   border-radius: 50%;
   overflow: hidden;
   box-shadow: 0 0 20px rgba(0, 0, 0, 0.2);
}

.photo img {
   max-width: 100%;
   height: auto;
}

.name {
   font-family: 'Fineday', cursive;
   font-size: 30px;
   font-weight: 500;
   line-height: 120%;
   color: #12be83;
}

.chat-text {
   margin: 15px 20px 0 20px;
   font-size: 14px;
   font-weight: 500;
   line-height: 110%;
   color: #121B23;
   text-align: center;
}

.chat-text.last {
   margin-top: 5px;
}

.chat-text strong {
   color: #12be83;
   font-weight: 600;
}

.chat-text.thanks {
   font-size: 17px;
   font-weight: 600;
}

.chat-text.dancing {
   font-family: 'Astrum', cursive;
   font-size: 25px;
   line-height: 95%;
   color: #12be83;
}

.chat-content {
   opacity: 1;
   visibility: visible;
}

.chat-content.thanks {
   padding: 20px 0 40px 0;
}

.chat-footer {
   padding: 5px 20px;
   font-size: 13px;
   font-weight: 500;
   line-height: 120%;
   color: #9292a6;
   text-align: center;
   background: #e6e6eb;
}


.fadeChat-enter-active, .fadeChat-leave-active {
   transition: all 0.3s ease-out;
}
.fadeChat-enter, .fadeChat-leave-to {
   opacity: 0;
   visibility: hidden;
   bottom: -20px;
}


.fadeChatContent-enter-active, .fadeChatContent-leave-active {
   transition: all 0.3s ease-out;
}
.fadeChatContent-enter, .fadeChatContent-leave-to {
   opacity: 0;
   visibility: hidden;
}

@media all and (max-width: 365px) {
   .modal-chat-wrap { max-width: 85vw; }
}

@media all and (max-height: 666px) {
   .modal-chat-wrap { position: absolute; }
}


</style>