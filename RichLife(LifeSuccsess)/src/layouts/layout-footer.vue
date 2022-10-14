<template>    
    <footer>
        <i-container class="footer-conatiner">
            <div class="row footer-row">
                <div class="col-4 footer-col">
                    <div class="footer-item">
                        <h4 class="i-title sm-title footer-title">измени будущее</h4>
                        <p class="i-text footer-text">Измени свое будущее прямо сейчас: </p>
                        <i-button @onClick="$emit('getInTouch')" class="grey tt-u i-button-link">Оставить заявку</i-button>
                        <router-link class="grey tt-u i-button-link mt10" to="take-a-program">Оставить заявку</router-link>
                    </div>
                </div>

                <div class="col-4 footer-col">
                    <div class="footer-item">
                        <h4 class="i-title sm-title footer-title">Подпишитесь</h4>
                        <p class="i-text footer-text">Вдохновляйся и первым узнавай о новостях Компании в наших социальных сетях!</p>
                        <div class="social-block">
                            <a href=""><svg><use xlink:href="/assets/img/svg-sprite.svg#icon-vk"></use></svg></a>
                            <a href=""><svg><use xlink:href="/assets/img/svg-sprite.svg#icon-youtube"></use></svg></a>
                            <a href=""><svg><use xlink:href="/assets/img/svg-sprite.svg#icon-instagram"></use></svg></a>
                            <a href=""><svg><use xlink:href="/assets/img/svg-sprite.svg#icon-whatsapp"></use></svg></a>
                            <a href=""><svg><use xlink:href="/assets/img/svg-sprite.svg#icon-telegram"></use></svg></a>
                            <a href=""><svg><use xlink:href="/assets/img/svg-sprite.svg#icon-viber"></use></svg></a>
                        </div>
                    </div>
                </div>

                <div class="col-4 footer-col">
                    <div class="footer-item">
                        <logo />
                        <p class="copyright">&copy; 2019-2021 ООО «Life Success»</p>
                    </div>
                </div>
            </div>
        </i-container>
    </footer>
</template>

<script lang="ts">

import Vue from "vue";
import { Component } from 'vue-property-decorator'

@Component
export default  class FooterComponent extends Vue {

}
</script>

<style scoped>

footer {
    padding: 50px 0;
    background: url('/assets/img/footer/footer-bg1.webp') center no-repeat;
    background-size: cover;
    width: 100%;
    box-shadow: 0 0 42px rgba(0, 0, 0, 0.3);
    position: relative;
}

footer::after {
    content: '';
    position: absolute;
    top: 0;
    left: 0;
    width: 100%;
    height: 100%;
    background: rgba(13, 166, 113, 0.8);
}

.footer-conatiner {
    position: relative;
    z-index: 1;
}

.footer-col {
    display: flex;
}

.footer-item {
    display: flex;
    flex-direction: column;
    align-items: flex-start;
}

.footer-title,
.footer-text {
    color: #fff;
    text-align: left;
}

.footer-text {
    font-weight: 400;
}




/* socials */
.social-block {
    display: flex;
    align-items: center;
}

.social-block a {
    display: flex;
    width: 30px;
    height: 30px;
}

.social-block a:not(:last-child) {
    margin-right: 7px;
}

.social-block svg {
    width: 32px;
    height: 32px;
    fill: #fff;
    transition: all 0.2s ease-out;
}

.social-block svg:hover {
    fill: #e6e6eb;
}


/* copyright */
.copyright {
    margin-top: 20px;
    font-size: 15px;
    font-weight: 400;
    line-height: 120%;
    color: #fff;
    text-align: center;
}


@media all and (max-width: 910px) {
    .footer-col { flex: 0 0 50%; max-width: 50%; margin-bottom: 30px; }
}

@media all and (max-width: 520px) {
    .footer-col { flex: 0 0 100%; max-width: 100%; margin-bottom: 60px; }
    .footer-col:nth-child(1) { order: 2; }
    .footer-col:nth-child(2) { order: 3; }
    .footer-col:nth-child(3) { order: 4; }
    .footer-col:nth-child(4) { order: 1; }
}
</style>