const windowWidth = window.innerWidth
const windowHeight = window.innerHeight


/**
 * Preloader
 */
window.addEventListener('load', function () {
   setTimeout(() => {
      $('.preloader').addClass('hide')
   }, 1000)
})


/**
 * Открытие/Закрытие мобильного меню
 */

function OpenMobileMenu(burgerIcon, overlay, mobileMenu) {
   $(burgerIcon).on('click', function() {
      $(mobileMenu).toggleClass('show')
      $(overlay).toggleClass('show')
      $('body').toggleClass('notScroll')
   })
}

function CloseMobileMenu(mobileMenu, overlay) {
   $(mobileMenu).removeClass('show')
   $(overlay).removeClass('show')
   $('body').removeClass('notScroll')
}



let openMobileMenu = new OpenMobileMenu('.mobile-menu-icon', '.menu-overlay', '.mobile-menu')
let closeMobileMenu

$('.menu-close').on('click', function() {
   closeMobileMenu = new CloseMobileMenu('.mobile-menu', '.menu-overlay')
})

$('.menu-overlay').on('click', function() {
   closeMobileMenu = new CloseMobileMenu('.mobile-menu', '.menu-overlay')
})

document.body.onkeydown = function (e) {
   if (e.keyCode == 27) 
      closeMobileMenu = new CloseMobileMenu('.mobile-menu', '.menu-overlay')
};









/**
 * Анимация чисел при скролле
 */

let featuresNumbers = document.querySelectorAll('.features-numbers')
let numbersRow = document.querySelector('.numbers-row')

window.addEventListener('scroll', function() {
   if (numbersRow.classList.contains('animate-show')) {
      animateFeaturesCouner()
   }
})

function animateFeaturesCouner() {
   for (let i = 0; i < featuresNumbers.length; i++) {
      let numberItem = featuresNumbers[i].querySelector('.features-number')
      let number = numberItem.getAttribute('data-number')
   
      numberItem.innerText = number
      // counter(number, numberItem, 2000, 1)
      
   }
  
}







/**
 * Модальное окно
 */

$('.i-button.signUp').on('click', function () {
   openModalWindow('.i-modal.signUp', '.form-wrap.signUp')
})

$('.i-button.signIn').on('click', function () {
   openModalWindow('.i-modal.signIn', '.form-wrap.signIn')
})

$('.i-close').on('click', function () {
   closeModalWindow('.i-modal', '.form-wrap')
   closeMobileMenu = new CloseMobileMenu('.mobile-menu', '.menu-overlay')
})

$('.i-modal-content').on('click', function (e) {
   if (this == e.target) {
      closeModalWindow('.i-modal', '.form-wrap')
      closeMobileMenu = new CloseMobileMenu('.mobile-menu', '.menu-overlay')
   }
})

document.body.onkeydown = function (e) {
   if (e.keyCode == 27) {
      closeModalWindow('.i-modal', '.form-wrap')
      closeMobileMenu = new CloseMobileMenu('.mobile-menu', '.menu-overlay')
   }
};






function closeModalWindow(modalWindow, form) {
   $(modalWindow).removeClass('show')
   $(form).removeClass('show')
   $('body').removeClass('notScroll')
   $('.form-item').removeClass('error')
   $('.form-item span').text('')
   $('.checkbox').removeClass('error').removeClass('checked')
}

function openModalWindow(modalWindow, form) {
   $(modalWindow).addClass('show')
   $(form).addClass('show')
   $('body').addClass('notScroll')
}









/**
 * Плавный переход по ссылкам
 */
 $(function () {
   $('a[href^="#"]').on('click', function (e) {
      e.preventDefault();
      $('.lazy-link').removeClass('active').filter(this).addClass('active'); 
      var selector = $(this).attr('href'); 
      var h = $(selector);

      $('html, body').animate({
         scrollTop: h.offset().top - 60
      }, 1000);
   });
});






/**
 * слайдер на главной
 */ 

$('.main-slider').on('init', function(event, slick) {})
// настройки слайдера
.slick({ 
   slidesToShow: 1,
   slidesToScroll: 1,
   dots: true,
   arrows: false,
   fade: false,
   useTransform: true,
   cssEase: 'cubic-bezier(.19,.74,0,1.01)',
   accessibility: true,
   autoplay: false,
   autoplaySpeed: 8000,
   speed: 1600,
   infinite: true,
   pauseOnFocus: false,
   pauseOnHover: false,
   // adaptiveHeight: true
   // responsive: [
   //    {
   //      breakpoint: 1221,
   //      settings: {
   //       slidesToShow: 1,
   //       slidesToScroll: 1,
   //       dots: false,
   //       arrows: false,
   //       fade: false,
   //       useTransform: true,
   //       cssEase: 'cubic-bezier(.19,.74,0,1.01)',
   //       accessibility: true,
   //       autoplay: false,
   //       autoplaySpeed: 8000,
   //       speed: 1600,
   //       infinite: true,
   //       pauseOnFocus: false,
   //       pauseOnHover: false,
   //      }
   //    }
   //  ]
})

displaySlickDots()
coutDotsSlider()

window.addEventListener('resize', function () {
   displaySlickDots()
   setTimeout(() => {
      coutDotsSlider()
   }, 100)
})


/* Изменение стилей slick-dots */
function displaySlickDots() {
   let windowWidth = window.innerWidth
   if (windowWidth <= 1220) {
      $('.slick-dots').css({ display: 'none' })
   } else {
      $('.slick-dots').css({ display: 'flex' })
   }
}

/* Замена стандартных точек на цифры в главном слайдере */
function coutDotsSlider() {
   let slickDots = document.querySelectorAll('.slick-dots li')
   for (let i = 0; i < slickDots.length; i++) {
      let number = i + 1
      if (slickDots.length <= 9) 
         number = '0' + (i + 1)
      slickDots[i].innerText = number
   }
}




/**
 * Анимированное появление header при загрузке страницы
 */
window.addEventListener('load', function () {
   $('header').addClass('animate-header')
})





/**
 * Checkbox
 */
$('.checkbox').on('click', function() {
   $(this).toggleClass('checked')
   if ($(this).hasClass('checked')) {
      $(this).removeClass('error')
   }
})



/**
 * Валидация форм
 */

let userName = $('input[name=user_name]')
let surname = $('input[name=user_surname]')
let cardCode = $('input[name=user_card-code]')
let email = $('input[name=user_email]')
let password = $('input[name=user_password]')
let repeatPassword = $('input[name=user_repeat-password]')
let phone = $('input[name=user_phone]')

let regName = /^[A-zА-я\s^_][^0-9\s_]+$/ // валидация имени
let regPhone = /^[0-9\s][^A-zА-я\s_\.\,]+$/  // валидация 

let error = false

$('form').on('submit', function (e) {

   // имя
   if (userName.val() == '') {
      e.preventDefault()
      setError(userName, "Заполните поле")
   } else if (!regName.test(userName.val())) {
      e.preventDefault()
      setError(userName, 'Введите корректные данные')
   } else {
      removeError(userName)
   }

   // Фамилия
   if (surname.val() == '') {
      e.preventDefault()
      setError(surname, "Заполните поле")
   } else if (!regName.test(surname.val())) {
      e.preventDefault()
      setError(surname, 'Введите корректные данные')
   } else {
      removeError(surname)
      error = false
   }

   // Номер карты (6-ти значный код на карте чк)
   if (cardCode.val() == '') {
      e.preventDefault()
      setError(cardCode, "Заполните поле")
   } else if (!regPhone.test(cardCode.val())) {
      e.preventDefault()
      setError(cardCode, 'Введите корректные данные')
   } else {
      removeError(cardCode)
      error = false
   }

   // пароль
   if (password.val() == '') {
      e.preventDefault()
      setError(password, "Заполните поле")
   } else {
      removeError(password)
      error = false
   }

   // Повторить пароль
   if (repeatPassword.val() == '') {
      e.preventDefault()
      setError(repeatPassword, "Заполните поле")
   } else if (password.val() != repeatPassword.val()) {
      e.preventDefault()
      setError(repeatPassword, 'Пароли не совпадают')
   } else {
      removeError(repeatPassword)
      error = false
   }

   // Номер телефона
   if (phone.val() == '') {
      e.preventDefault()
      setError(phone, "Заполните поле")
   } else if (!regPhone.test(phone.val())) {
      e.preventDefault()
      setError(phone, 'Введите корректные данные')
   } else {
      removeError(phone)
      error = false
   }

   /* email */
   if (email.val() == '') {
      e.preventDefault()
      setError(email, 'Введите Ваш email')
   } else if (!isEmail(email.val())) {
      
      setError(email, 'Введите корректный email')
   } else {
      removeError(email)
      error = false
   }

   /* Checkbox */
   if ($('.checkbox').hasClass('checked')) {
      $('.checkbox').removeClass('error')
   } else {
      e.preventDefault()
      $('.checkbox').addClass('error')
   }
})



function setError(input, errorMessage) {
   let parent = input.parents('.form-item')
   let mess = parent.find('span')

   parent.addClass('error')
   mess.text(errorMessage)
}

function removeError(input) {
   let parent = input.parents('.form-item')
   let mess = parent.find('span')

   parent.removeClass('error')
   mess.text('')
}

function isEmail(email) {
   return /^(([^<>()\[\]\\.,;:\s@"]+(\.[^<>()\[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/.test(email);
}


