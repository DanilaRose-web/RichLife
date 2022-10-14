/**
 * Анимация счетчика чисел
 */
 function counter(count, elem, duration, step) {
   
   let n = 0;
   let t = Math.round(count / (duration / 100));
   // console.log(t, 't');
   let interval = setInterval(() => {
      firstAnimate = true
      n = n + step;
      elem.innerHTML = n;
      if (n == count) {
         clearInterval(interval);
      } 
   }, 0.000000000000002); 
}


// function animateValue(elem, start, end, duration) {
//    let startTimestamp = null;
//    const step = (timestamp) => {
//      if (!startTimestamp) startTimestamp = timestamp;
//      const progress = Math.min((timestamp - startTimestamp) / duration, 1);
//      elem.innerHTML = Math.floor(progress * (end - start) + start);
//      if (progress < 1) {
//        window.requestAnimationFrame(step);
//      }
//    };
//    window.requestAnimationFrame(step);
// }
