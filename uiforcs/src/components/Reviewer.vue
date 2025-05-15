
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
  <div id="reviewer">
    <h1>{{word}}</h1>
    <div id="infoContainer">
      <pre v-if="showInfo" id="info">{{info}}</pre>
    </div>
    <div>
      <button @click="toggleInfo" v-if="showButton">认识</button>
      <button @click="toggleInfo" v-if="showButton">不认识</button>
      <button @click="toggleInfo" v-if="!showButton">下一个</button>
    </div>
  </div>
</template>

<style scoped>
#reviewer {
  background-color: #e1e1e1;
  height: 800px;
  width: 600px;
  color: black;
  display: flex;
  flex-direction: column;
  align-items: center;
  justify-content: center;
}

#reviewer h1 {
  bottom: 20px;
}
#infoContainer{
  background-color: rgba(255, 255, 255, 0.64);
  height: 500px;
  width: 450px;
}
#infoContainer pre{
  margin-left: 10px;
  margin-top: 10px;
}
</style>