<template>
  <div class="notifications container" style="margin-top:50px">
    <Alert v-if="alert" v-bind:message="alert" />
    <h1 class="page-header">Powiadomienia</h1>

    <br />

 
    
    <table class="table table-striped">
      <thead>
        <tr>
          <th>Temat</th>
          <th>Pokaż</th>
         

          <th></th>
        </tr>
      </thead>
      <tbody>
        <tr v-for="notification in notifications">
          <td>{{notification.subject}}</td>

          <td>
            <router-link class="btn btn-default" v-bind:to="'/Notifications'+Notification.id">Pokaż</router-link>
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
  notifications: [{subject: ''}],
  alert:'',
  }
  },
  methods: {
  fetchNotifications(){
  this.$http.get('https://localhost:44335/api/Notification/GetAllNotifications')
  .then(function(response){
  this.notifications = response.body;
  });
  }
  }
  };
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped="">
</style>
