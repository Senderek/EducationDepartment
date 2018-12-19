<template>
<div class="text-center">
 <h1>typ: {{publications[ide-1].type}}</h1>
 <h1>tytuł: {{publications[ide-1].title}}</h1>
 <h1>autor: {{publications[ide-1].autor}}</h1>
 <h1>data: {{publications[ide-1].date}}</h1>

 <router-link class="btn btn-info" v-bind:to="'/'">Wróć</router-link>
</div>
</template>
<script>
  export default {
  name: 'SignIn',
  data(){
  return{
  ide: this.$route.params.id,
  publications: [{type:'Artykuł',title:'VUE.JS',autor:'Jan Kowalski',date:'2018-12-15',id:'1'},{type:'Książka',title:'ASP.NET.JS',autor:'Adam Nowak',date:'2017-10-13',id:'2'},{type:'Monografia',title:'C#',autor:'Marcin Wójcik',date:'2016-10-15',id:'3'},{type:'Raport',title:'Wykład C++',autor:'Michał Adamiak',date:'2018-11-16',id:'4'}]}
  }
  };
  </script>
  <style scoped="">
</style>