<template>
   <transition name="showModal">
      <div class="i-modal" v-if="innerShow">
         <div class="i-modal-content-wrap" ref="modalContentWrap">
            <div class="i-modal-content" :style="getStyleIModalContent()" :class="{'show' : innerShow}">
               <div class="i-close" @click="close">
                  <svg><use xlink:href="/assets/img/svg-sprite.svg#icon-close"></use></svg>
               </div>

               <slot />
            </div>
         </div>
      </div>
   </transition>
</template>

<script lang="ts">
import Vue from "vue";
import { Component, Prop, Watch } from "vue-property-decorator"

@Component
export default class IModalComponent extends Vue {
   @Prop({ type: Boolean, default: false }) show: boolean
   @Prop({ type: String, default: '1000px' }) contentMaxWidth: string

   // innerShow: boolean = false
   innerShow: boolean = false

   @Watch('show') change() {
      this.innerShow = this.show
      console.log(this.show, 'show');
      
      let bodyOverflowHidden = document.querySelector('body')
      
      if (this.innerShow) 
         bodyOverflowHidden.classList.add('hidden')
         else bodyOverflowHidden.classList.remove('hidden')
   }

   created() {
      this.innerShow = this.show
   }

   mounted() {
      document.addEventListener('click', this.clickOutside)
      document.body.addEventListener('keydown', this.clickOutside)
   }

   destroyed() {
      document.removeEventListener('click', this.clickOutside)
      document.body.removeEventListener('keydown', this.clickOutside)
   }

   /**
    * Закрытие окна
    */
   close() {
      this.innerShow = false
      this.$emit('close')
      // console.log(this.innerShow, 'innerShow');
   }

   /**
    * Закрытие при клике вне окна
    */
   clickOutside(event: any) {
      if (event.target == this.$refs.modalContentWrap || event.keyCode == 27)
         this.close()
   }

   /**
    * Стили props для i-modal-conten
    */
   getStyleIModalContent(): Object {
      return {
         maxWidth: this.contentMaxWidth
      }
   }

   
}
</script>

<style scoped>

.i-modal {
   padding: 0 15px;
   position: fixed;
   left: 0;
   top: 0;
   width: 100%;
   height: 100%;
   box-shadow: 20px 20px 50px rgba(0, 0, 0, 0.5);
   background: rgba(0, 0, 0, 0.9);
   /* backdrop-filter: blur(5px); */
   display: grid;
   grid-template-columns: 1fr;
   grid-template-rows: 1fr;
   align-items: center;
   overflow: auto;
   justify-content: center;
   z-index: 3;
   opacity: 1;
   visibility: visible;
   transition: all 0.5s ease-out;
}

.i-modal.show {
   opacity: 1;
   visibility: visible;
}

.i-modal-content-wrap {
   margin: 30px 0;
   height: 100%;
   width: 100%;
   display: flex;
   align-items: center;
   justify-content: center;
}

.i-modal-content {
   padding: 40px;
   width: 100%;
   border-radius: 15px;
   box-shadow: 20px 20px 50px rgba(0, 0, 0, 0.5);
   background: rgba(255, 255, 255, 0.1);
   border-top: 1px solid rgba(255, 255, 255, 0.5);
   border-left: 1px solid rgba(255, 255, 255, 0.5);
   position: relative;
   overflow: hidden;
   opacity: 0;
   visibility: hidden;
   transform: scale(0.8);
   /* transition: all 0.5s ease-out; */
}

.i-modal-content.show {
   animation: showModalContent 0.5s ease-out 0.5s forwards;
}


@keyframes showModalContent {
   0% { opacity: 0; visibility: hidden; transform: scale(0.8); }
   100% { opacity: 1; visibility: visible; transform: scale(1); }
}




/* крестик */
.i-close {
   display: flex;
   align-items: center;
   justify-content: center;
   width: 22px;
   height: 22px;
   position: absolute;
   top: 15px;
   right: 15px;
   cursor: pointer;
}

.i-close svg {
   width: 22px;
   height: 22px;
   fill: #F8F9FC;
   transition: all 0.2s ease-out;
}

.i-close:hover svg {
   fill: #12be83;
}

.i-close:active svg {
   transform: scale(0.8);
}


@media all and (max-width: 700px) {
   .i-modal-content { padding: 40px 15px; }
}





/* animation i-modal */
.showModal-enter-active, .showModal-leave-active {
   transition: all 0.5s ease-out;
}

.showModal-enter, .showModal-leave-to {
   opacity: 0;
   visibility: visible;
}




</style>