
<script setup>
import {onMounted, ref} from "vue";

const word = ref('');
const info = ref('');
const showInfo = ref(false);
const showButton = ref(true);

onMounted(async () => {
  const response = await fetch('http://localhost:5200/api/ReviewWord');
  const data = await response.json();
  word.value = data.wordOfReview;
  info.value = data.infoOfReview;
  console.log(data);
});
function toggleInfo() {
  showInfo.value = !showInfo.value;
  showButton.value = !showButton.value;
}
</script>

<template>
  <div id="reviewer" class="card">
    <h1 class="card-title">{{word}}</h1>
    <div id="infoContainer" class="card">
      <pre v-if="showInfo" id="info">{{info}}</pre>
    </div>
    <div>
      <button id="define-btn" @click="toggleInfo" v-if="showButton" type="button" class="btn btn-light">认识</button>
      <button id="define-btn" @click="toggleInfo" v-if="showButton" type="button" class="btn btn-light">不认识</button>
      <button id="next-btn" @click="toggleInfo" v-if="!showButton" type="button" class="btn btn-primary">下一个</button>
    </div>
  </div>
</template>

<style scoped>
#define-btn{
  height:  60px;
  width: 225px;
  margin-bottom: 20px;
}
#next-btn{
  height:  60px;
  width: 450px;
  margin-bottom: 20px;
}
#reviewer {
  background-color: #eaeaea;
  background-image: url("https://img.picui.cn/free/2025/05/15/6825e30d94b60.jpg");

  height: 800px;
  width: 600px;
  color: black;
  display: flex;
  flex-direction: column;
  align-items: center;
  justify-content: center;
}

#reviewer h1 {
  margin-top: 150px;
  color: white;
  font-weight: bold;
  text-shadow:
      -2px -2px 0 #000,
      2px -2px 0 #000,
      -2px  2px 0 #000,
      2px  2px 0 #000;
}
#infoContainer{
  background-color: rgba(255, 255, 255, 0.64);
  height: 450px;
  width: 450px;
  margin-top:100px ;
}
#infoContainer pre{
  margin-left: 10px;
  margin-top: 5px;
}
</style>