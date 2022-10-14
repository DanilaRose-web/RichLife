<template>

   <layout @showJoinModalFooter="onShowJoinModalFooter" @getInTouch="onGetInTouch">
      <template slot="header">
         <minimal-header-metlife @getInTouch="onGetInTouch" @openNote="openNoteModal" @changeShow="onChangeShow" :innerShowMenu="innerShowMenu" @callUs="onCallUs" class="static" @showJoinModal="onShowJoinModal" @showGetInTouch="onGetInTouch" />

         <!-- <services-static-menu>
            <ul class="static-menu">
               <li><router-link to="childhood-critical-illness">Детское страхование от критических заболеваний</router-link></li>
               <li class="active"><router-link to="loss-of-breadwinner">Страхование в случае потери кормильца</router-link></li>
               <li><router-link to="capital-for-children">Накопление капитала для детей</router-link></li>
               <li><router-link to="pension-capital">Накопление на собственную пенсию</router-link></li>
            </ul>
         </services-static-menu> -->
      </template>

      <breadcrumbs>
         <router-link to="/">Главная <svg><use xlink:href="/assets/img/svg-sprite.svg#arrows-breadcrumb"></use></svg></router-link>
         <router-link to="metlife">MetLife <svg><use xlink:href="/assets/img/svg-sprite.svg#arrows-breadcrumb"></use></svg></router-link>
         <!-- <router-link to="insurance-for-family">Страхование для моей семьи <svg><use xlink:href="/assets/img/svg-sprite.svg#arrows-breadcrumb"></use></svg></router-link> -->
         <span>Страхование в случае потери кормильца</span>
      </breadcrumbs>

      <section class="section-main i-section">
         <i-container>
            <span class="i-title dancing">Loss of Breadwinner</span>
            <h1 class="i-title section-title">Потеря кормильца семьи</h1>
            <h4 class="i-subtitle">Финансовая помощь в связи с потерей кормильца семьи</h4>
         
            <h3 class="static-md-title">Финансовая помощь в связи с потерей кормильца семьи</h3>
            
            <div class="descr-wrap">
               <div class="descr-block">
                  <p>Наша жизнь всегда полна неожиданных и спонтанных событий. В жизни большинства из нас были моменты, которые меняли все, переворачивали всю жизнь, меняли судьбу и радикально влияли на будущее. Хорошие или плохие, счастливые или нет, эти внезапные события имеют одно незыблемое всеобщее - они всегда происходят неожиданно.</p>
               </div>
               <div class="descr-block">
                  <p>Бесспорно, мир вокруг нас стал гораздо безопаснее, чем он был 500 лет назад, но все же лучше позаботиться о себе и своих близких сейчас, ведь мы на самом деле не знаем, что с нами может произойти уже через минуту, час, день.</p>
               </div>
               <div class="descr-block">
                  <p>МетЛайф, мировой лидер и компания, которая положила начало в истории примера массового страхования от несчастного случая, предлагает лучшие решения, которые придают вам уверенность в том, что ваша семья будет обеспечена даже в случае досадных жизненных ситуаций с Вами как кормильцем.</p>
               </div>
            </div>

            <div class="navigate-block">
               <div class="navigate-row row">
                  <div class="col-6 navigate-col">
                     <router-link to="program-term" class="navigate-link">
                        <div class="watermark">01</div>
                        <h3>Программа страхования TERM</h3>
                        <p>Страхование на случай смерти на определенный срок или до определенного возраста</p>
                     </router-link>
                  </div>
                  <div class="col-6 navigate-col">
                     <router-link to="program-adob" class="navigate-link">
                        <div class="watermark">02</div>
                        <h3>Программа страхования ADob</h3>
                        <p>Страхование на случай смерти в результате несчастного случая с выплатой дополнительной страховой суммы на случай сиротства</p>
                     </router-link>
                  </div>
                  <div class="col-6 navigate-col">
                     <router-link to="program-ad-traffic" class="navigate-link">
                        <div class="watermark">03</div>
                        <h3>Программа страхования AD Traffic</h3>
                        <p>Страхование на случай смерти в результате несчастного случая на транспорте</p>
                     </router-link>
                  </div>
                  <div class="col-6 navigate-col">
                     <router-link to="program-cpa" class="navigate-link">
                        <div class="watermark">04</div>
                        <h3>Программа страхования CPA</h3>
                        <p>Страхование на случай смерти или постоянной и полной нетрудоспособности страхователя (освобождение от уплаты страховых премий) по детской программе накопления</p>
                     </router-link>
                  </div>
               </div>
            </div>
         </i-container>
      </section>

      <!-- Форма регистрации -->
      <i-modal :contentMaxWidth="'600px'" :show="showJoinModal" @close="onHideJoinModal" >
         <join-form></join-form>
      </i-modal>

      <!-- Модалка проверки авторизации -->
      <i-modal :contentMaxWidth="'600px'" :show="noteGetInTouch" @close="noteGetInTouch = false">
         <notification-get-in-touch @click="onShowJoinModal"></notification-get-in-touch>
      </i-modal>

      <!-- Форма "Оставить заявку" -->
      <i-modal :contentMaxWidth="'600px'" :show="getInTouch" @close="getInTouch = false">
         <get-in-touch></get-in-touch>
      </i-modal>

      <modal-chat :innerOpen="openChat" @closeChat="onCloseChat"></modal-chat>
   </layout>
</template>

<script lang="ts">
import Vue from "vue";
import { Component } from "vue-property-decorator"

import cookie from "js-cookie"

@Component
export default class PageLossOfBreadwinnerComponents extends Vue {  // Страница - Страхование жизни

   showJoinModal: boolean = false  // флаг на открытие формы join
   getInTouch: boolean = false // флаг на открытие модального окна "оставить заявку"
   openChat: boolean = false // открытие окна с чатом при клике на "связаться с нами" из services-menu
   innerShowMenu: boolean = false
   noteGetInTouch: boolean = false // фдаг на открытие окна с проверкой на авторизацию


   /**
    * Emit, который передает значение флага для открытия формы join из layout (т.к. layout-footer инициализируется в layout, а не на этой странице)
    */
   onShowJoinModalFooter(showJoinModalFooter: boolean) {
      this.showJoinModal = showJoinModalFooter
   }

   /**
    * Открытие модального окна с формой join
    */
   onShowJoinModal() {
      this.showJoinModal = true
      this.noteGetInTouch = false
      this.$emit('showJoin', this.showJoinModal)
   }

   /**
    * Закрытие модального окна с формой join
    */
   onHideJoinModal() {
      this.showJoinModal = false
   }

   /**
    * Окрытие окна с чатом при клике на "связаться с нами" из services-menu
    */
   onCallUs() {
      this.openChat = true
      this.innerShowMenu = false
   }

   onChangeShow(show: boolean) {
      this.innerShowMenu = show
   }

   /**
    * Передача флага open: false, из компонента modal-chat при закрытии чата
    */
   onCloseChat(open: boolean) {
      this.openChat = open
   }

   /**
    * Открытие модального окна с проверкой на авторизацию
    */
   openNoteModal() {
      this.noteGetInTouch = true
   }

   /**
    * Открытие модалки на проверку авторизации, при клике на "Оставить заявку"
    */
   onGetInTouch() {
      if (cookie.get('token') == '' || cookie.get('token') == undefined) {
         this.noteGetInTouch = true
      } else {
         this.getInTouch = true
      }
   }

}
</script>

<style scoped>

.static-md-title {
   margin: 70px auto 0 auto;
   font-size: 20px;
   font-weight: 700;
   line-height: 140%;
   color: #121B23;
   text-align: center;
   max-width: 900px;
}

.descr-wrap {
   margin: 0 auto;
   max-width: 1000px;
}

.descr-block {
   margin-top: 60px;
   padding: 20px;
   position: relative;
   background: #F8F9FC;
   border-radius: 15px;
   box-shadow: 0 0 20px rgba(0, 0, 0, 0.1);
}

.descr-block::before {
   content: '';
   position: absolute;
   top: -30px;
   left: -30px;
   width: 70px;
   height: 70px;
   background: url('/assets/img/backgrounds/dots-bg.webp') no-repeat center;
   background-size: cover;
   z-index: -1;
}

.descr-block p {
   font-size: 15px;
   font-weight: 500;
   line-height: 150%;
   color: #121B23;
}





.navigate-block {
   margin: 100px auto 0 auto;
   max-width: 1000px;
}


.navigate-col {
   margin-bottom: 30px;
   display: flex;
}

.navigate-link {
   padding: 20px;
   display: flex;
   flex-direction: column;
   align-items: center;
   width: 100%;
   position: relative;
   box-shadow: 0 0 20px rgba(0, 0, 0, 0.1);
   border-radius: 15px;
   transition: all 0.2s ease-out;
}

.navigate-link .watermark {
   position: absolute;
   top: 5px;
   left: 5px;
   font-size: 100px;
   font-weight: 700;
   color: rgba(18, 190, 131, 0.1);
   transition: all 0.2s ease-in-out;
}

.navigate-link h3 {
   margin-bottom: 15px;
   font-size: 19px;
   font-weight: 700;
   color: #121B23;
   line-height: 140%;
   text-align: center;
   transition: all 0.2s ease-out;
}

.navigate-link p {
   font-size: 15px;
   font-weight: 500;
   line-height: 140%;
   color: #121B23;
   text-align: center;
}

.navigate-link:hover {
   transform: translateY(-7px);
}

.navigate-link:hover .watermark {
   color: rgba(250, 205, 212, 0.3);
}

.navigate-link:hover h3 {
   color: #12be83;
}


@media all and (max-width: 590px) {
   .navigate-col { flex: 0 0 100%; max-width: 100%; }
}
</style>