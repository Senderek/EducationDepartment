<template>
  <div class="publications container">
    <Alert v-if="alert" v-bind:message="alert" />
    <h1 class="page-header">Publikacje</h1>
    <input class="form-control" placeholder="Wpisz tytuł" v-model="filterInput">
      <br />

   

      <table class="table table-striped">
        <thead>
          <tr>
            <th>Typ Publikacji</th>
            <th>Tytuł</th>
            <th>Autor</th>
            <th>Data</th>
            <th></th>
          </tr>
        </thead>
        <tbody>
          <tr v-for="publication in filterBy(publications, filterInput)">
            <td>{{publication.type}}</td>
            <td>{{publication.title}}</td>
            <td>{{publication.autor}}</td>
            <td>{{publication.date}}</td>
            <td>
              <router-link class="btn btn-info" v-bind:to="'/publications/'+publication.id">Pokaż</router-link>
            </td>
          </tr>
        </tbody>
      </table>
    </div>
</template>

<script>
  import Alert from './Alert';
  export default {
  name: 'Publications',
  data () {
  return {
  publications: [{type:'Artykuł',title:'VUE.JS',autor:'Jan Kowalski',date:'2018-12-15',id:'1'},{type:'Książka',title:'ASP.NET.JS',autor:'Adam Nowak',date:'2017-10-13',id:'2'},{type:'Monografia',title:'C#',autor:'Marcin Wójcik',date:'2016-10-15',id:'3'},{type:'Raport',title:'Wykład C++',autor:'Michał Adamiak',date:'2018-11-16',id:'4'}],
  selected:{},
  sorts:[{type:'Najstarsze'},{type:'Najnowsze'},{type:'Monografie'},{type:'Artykuły'},{type:'Raporty'},{type:'Patenty'}],
  alert:'',
  filterInput:''
  }
  },
  methods: {
  fetchPublications(){
  this.$http.get('https://localhost:44335/api/Articles' )
  .then(function(response){
  this.publications = response.body;
  });
  },
  filterBy(list, value){
  value = value.charAt(0).toUpperCase() + value.slice(1);
  return list.filter(function(publication){
  return publication.title.indexOf(value) > -1;
  });
  }
  },
  created: function(){
  if(this.$route.query.alert){
  this.alert = this.$route.query.alert;
  }
  this.fetchPublications();
  },
  updated: function(){
  this.fetchPublications();
  },
  components: {
  Alert
  }
  }
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped="">
</style>
