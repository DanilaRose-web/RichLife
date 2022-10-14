<template>
   <layout @showJoinModalFooter="onShowJoinModalFooter" @getInTouch="onGetInTouch">
      <template slot="header">
         <minimal-header-metlife @getInTouch="onGetInTouch" @openNote="openNoteModal" @changeShow="onChangeShow" :innerShowMenu="innerShowMenu" @callUs="onCallUs" class="static" @showJoinModal="onShowJoinModal" @showGetInTouch="onGetInTouch" />

         <!-- <services-static-menu>
            <ul class="static-menu">
               <li class="active"><router-link to="pension-provision">Дополнительное пенсионное обеспечение</router-link></li>
               <li><router-link to="accumulation-programs">Комплексные программы накопления</router-link></li>
            </ul>
         </services-static-menu> -->
      </template>

      <breadcrumbs>
         <router-link to="/">Главная <svg><use xlink:href="/assets/img/svg-sprite.svg#arrows-breadcrumb"></use></svg></router-link>
         <router-link to="metlife">MetLife <svg><use xlink:href="/assets/img/svg-sprite.svg#arrows-breadcrumb"></use></svg></router-link>
         <!-- <router-link to="insurance-for-me">Страхование для меня <svg><use xlink:href="/assets/img/svg-sprite.svg#arrows-breadcrumb"></use></svg></router-link> -->
         <router-link to="life-insurance">Страхование жизни <svg><use xlink:href="/assets/img/svg-sprite.svg#arrows-breadcrumb"></use></svg></router-link>
         <span>Дополнительное пенсионное обеспечение</span>
      </breadcrumbs>

      <section class="section-main i-section">
         <i-container>
            <span class="i-title dancing">Pension Provision</span>
            <h1 class="i-title section-title">Дополнительное пенсионное обеспечение и накопления</h1>
            <h4 class="i-subtitle">Дополнительное пенсионное обеспечение и накопления к определенной значительного события - ваша финансовая независимость от детей, родственников и государства после прекращения трудовой деятельности.</h4>
         
            <h3 class="static-md-title">Компания «МетЛайф» предлагает следующие варианты осуществления страховой выплаты с возможностью получения выплаты по окончании срока накопления:</h3>
            
            <div class="descr-wrap">
               <div class="descr-block">
                  <h4>Единовременная выплата</h4>
                  <p>В случае дожития застрахованного лица до окончания срока действия Договора страхования, ЗАО «МетЛайф» осуществит страховую выплату на случай дожития, которая состоит из:</p>
                  <ul class="i-ul-list descr-list">
                     <li>Страховой суммы по программе страхования основных рисков (программы Е, PEAD, E Single, PE Single)</li>
                     <li>Суммы негарантированную Бонуса (Дополнительного Инвестиционного Дохода)</li>
                     <li>Суммы Специального Фонда Индексации (только в случае применения индексации).</li>
                  </ul>
                  <p>Страховую выплату на случай дожития может быть осуществлено одной суммой, или Застрахованное лицо может выбрать один из способов осуществления страховой выплаты, определенные в «Положении о порядке осуществления страховой выплаты».</p>
               </div>

               <h4 class="mt">Согласно письменному заявлению застрахованного лица (далее - получатель) страховая выплата может быть осуществлена ​​следующим образом:</h4>          
               
               <div class="descr-block">
                  <h4>Страховая выплата обусловленными равными частями (аннуитет на срок, уплачиваемый обусловленными равными частями)</h4>
                  <p>В случае избрания этого способа осуществления выплат получатель будет получать страховую выплату равными частями установленного им самим размера (размер аннуитетного Выплаты). В Приложении к Договору страхования, будет отправлен для подтверждения применения этого способа, будет определен период, в течение которого ЗАО «МетЛайф» будет осуществлять такие Аннуитетные выплаты. В случае смерти получателя до окончания действия «Положения о порядке осуществления страховой выплаты» ЗАО «МетЛайф» осуществит единовременную выплату, рассчитанную на дату смерти получателя, в размере всех неуплаченных будущих аннуитетные выплаты с учетом инвестиционного дохода. Такая выплата будет осуществлена ​​лицу, имеющему право на ее получение в соответствии с действующим законодательством.</p>
               </div>
               <div class="descr-block">
                  <h4>Страховая выплата в течение установленного периода (аннуитет на срок, уплачиваемый в течение оговоренного срока)</h4>
                  <p>В случае избрания этого способа осуществления выплат получатель будет получать страховую выплату равными частями в течение установленного им самим периода.  В Приложении к Договору страхования, будет отправлен для подтверждения применения этого способа, будет определен размер таких аннуитетных выплат. В случае смерти получателя до окончания действия «Положения о порядке осуществления страховой выплаты» ЗАО «МетЛайф» осуществит единовременную выплату, рассчитанную на дату смерти получателя, в размере всех неуплаченных будущих аннуитетные выплаты с учетом инвестиционного дохода. Такая выплата будет осуществлена лицу, имеющему право на ее получение в соответствии с действующим законодательством.</p>
               </div>
               <div class="descr-block">
                  <h4>Пожизненная пенсия (Пожизненный аннуитет)</h4>
                  <p>Получатель будет получать страховую выплату в форме пожизненной пенсии, то есть в форме регулярных сумм, которые будут выплачиваться ему до конца его жизни. Размер пенсии будет указано в соответствующем Приложении к Договору страхования. В случае смерти клиента выплата пенсии прекращается.</p>
               </div>
               <div class="descr-block">
                  <h4>Пожизненная пенсия, гарантированная на определенный срок (Пожизненный аннуитет, гарантированный на определенный срок)</h4>
                  <p>Если получатель выбирает этот способ выплат, размер и период, в течение которого будут осуществляться выплаты пенсии будет указано в соответствующем Приложении к Договору страхования, и получатель получать такие выплаты до конца его жизни.</p>
                  <p>В случае смерти получателя до окончания гарантированного периода ЗАО «МетЛайф» осуществит единовременную выплату, рассчитанную на дату смерти получателя, в размере всех неуплаченных до даты окончания гарантированного периода будущих аннуитетные выплаты с учетом инвестиций ного дохода. Такая выплата будет осуществлена ​​лицу, имеющему право на ее получение в соответствии с действующим законодательством.</p>
               </div>
               <div class="descr-block">
                  <h4>Пожизненная пенсия, которая может быть передана в размере 60% (Пожизненный аннуитет, который может быть передан супругам получателя в размере 60% от суммы пожизненного аннуитета)</h4>
                  <p>Получатель будет получать надлежащую страховую выплату в форме пожизненной пенсии, размер которой будет указан в Приложении к Договору страхования, будет отправлен для подтверждения применения этого способа. В случае смерти получателя, суммы в размере 60% от аннуитетных выплат будут выплачиваться также в форме пожизненной пенсии супругам получателя.</p>
               </div>
            </div>

            <div class="navigate-block">
               <div class="navigate-row row">
                  <div class="col-6 navigate-col">
                     <router-link to="program-e" class="navigate-link">
                        <div class="watermark">01</div>
                        <h3>Прогармма страхования Е</h3>
                        <p>Страхование на случай смерти или дожития</p>
                     </router-link>
                  </div>
                  <div class="col-6 navigate-col">
                     <router-link to="program-e-single" class="navigate-link">
                        <div class="watermark">02</div>
                        <h3>Программа страхования E Single</h3>
                        <p>Страхование на случай смерти или дожития с возможностью уплаты единовременной страховой премии</p>
                     </router-link>
                  </div>
                  <div class="col-6 navigate-col">
                     <router-link to="program-pead" class="navigate-link">
                        <div class="watermark">03</div>
                        <h3>Программа страхования PEAD</h3>
                        <p>Страхование на случай дожития до определенного возраста или на определенный срок</p>
                     </router-link>
                  </div>
                  <div class="col-6 navigate-col">
                     <router-link to="program-pe-single" class="navigate-link">
                        <div class="watermark">04</div>
                        <h3>PE Single</h3>
                        <p>Страхование на случай дожития до определенного возраста или на определенный срок с возможностью уплаты единовременной страховой премии</p>
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
export default class PagePensionProvisionComponents extends Vue {  // Страница - Дополнительное пенсионное обеспечение

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

.descr-wrap h4 {
   font-size: 18px;
   font-weight: 700;
   line-height: 120%;
   color: #121B23;
}

.descr-wrap h4.mt {
   margin-top: 40px;
}

.descr-block p {
   margin-top: 15px;
   font-size: 15px;
   font-weight: 500;
   line-height: 150%;
   color: #121B23;
}

.descr-list {
   margin: 20px 0;
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