<template>
  <div class="publicationTypes container">
    <Alert v-if="alert" v-bind:message="alert" />
    <h1 class="page-header">Typy publikacji</h1>

    <br />

 
    
    <table class="table table-striped">
      <thead>
        <tr>
          <th>Nazwa typu</th>
          <th>Wybierz</th>
           

          <th></th>
        </tr>
      </thead>
      <tbody>
        <tr v-for="publicationType in publicationTypes">
          <td>{{publicationType.type}}</td>

          <td>
            <router-link class="btn btn-info" v-bind:to="publicationType.rot">Wybierz</router-link>
          </td>
         
        </tr>
      </tbody>
    </table>
  </div>
</template>

<script>
  import Alert from './Alert';
  export default {
  name: 'PublicationTypes',
  data () {
  return {
  publicationTypes: [{type: 'Artykuł',rot: '/article/new'},{type: 'Monografia',rot: '/monograph/new'},{type: 'Książka',rot: '/book/new'},{type: 'Raport',rot: '/raport/new'},{type: 'Patent',rot: '/patent/new'},{type: 'Materiał konferncyjny',rot: '/conferenceArticle/new'},{type: 'Przykład',rot: '/example/new'}],
  alert:'',
  }
  },
  methods: {
  fetchPublicationTypes(){
  this.$http.get('https://localhost:44335//api/Article/GettAll')
  .then(function(response){
  this.publicationTypes = response.body;
  });
  }
  }
  };
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped="">
</style>
