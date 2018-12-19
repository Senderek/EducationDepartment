<template>
  <div class="userEdit">
    <form   style ="margin-top:50px" v-on:submit="updateCustomer">


      <div class="form-group">
        <h1 class="h3 mb-3 font-weight-normal">Edycja danych</h1>
        <label for="login">Login</label>
        <input type="text" class="form-control" v-model="account.login" placeholder="login">
  </div>


      <div class="form-row">
        <div class="form-group col-md-6">
          <label for="name">Imię</label>
          <input type="text" class="form-control"  v-model="account.firstname" placeholder="imię">
    </div>
        <div class="form-group col-md-6">
          <label for="lastname">Nazwisko</label>
          <input type="text" class="form-control" v-model="account.lastname" placeholder="nazwisko">
    </div>
      </div>
      <label for="deegres">Stopień naukowy</label>
      </br>
      <div class="form-check form-check-inline">
        <input class="form-check-input" type="checkbox" id="degree1" value="inż">
          <label class="form-check-label" for="degree1">inż.</label>
        </div>
      <div class="form-check form-check-inline">
        <input class="form-check-input" type="checkbox" id="degree2" value="mgr">
          <label class="form-check-label" for="degree2">mgr</label>
        </div>
      <div class="form-check form-check-inline">
        <input class="form-check-input" type="checkbox" id="degree3" value="dr">
          <label class="form-check-label" for="degree3">dr </label>
        </div>
      <div class="form-check form-check-inline">
        <input class="form-check-input" type="checkbox" id="degree4" value="dr hab">
          <label class="form-check-label" for="degree4">dr hab. </label>
        </div>

      <div class="form-check form-check-inline">
        <input class="form-check-input" type="checkbox" id="degree5" value="prof">
          <label class="form-check-label" for="degree5">prof. </label>
        </div>

      <div class="form-group">
        <label for="emailSU">Email</label>
        <input type="email" class="form-control" v-model="account.email" placeholder="email">
  </div>

      <div class="form-row">
        <div class="form-group col-md-6">
          <label for="phoneSU">Telefon</label>
          <input type="text" class="form-control" v-model="account.phone" placeholder="telefon">
    </div>
        <div class="form-group col-md-6">
          <label for="faxSU">FAX</label>
          <input type="text" class="form-control" v-model="account.fax" placeholder="fax">
    </div>
      </div>
      <router-link class="btn btn-default" v-bind:to="'/account/changePassword/'+this.$route.params.id">Zmień hasło</router-link>

      <button type="submit" class="btn btn-lg btn-primary btn-block">Edytuj dane</button>
    </form>

  </div>
</template>

<script>
  import Alert from "./Alert"
  export default {
  name: "SingUp",
  data() {
  return {
  account: {},
  alert: ""
  }
  },
  methods:{
  fetchAccount(id){
  this.$http.get('https://localhost:44335/api/Account/'+id)
  .then(function(response){
  this.account = response.body;
  });
  },
  updateCustomer(e){
  if(!this.account.first_name || !this.account.last_name || !this.account.email){
  this.alert = 'Uzupełnij wymagane pola';
  } else {
  let updAccount = {
  firstName: this.account.firstname,
  lastName: this.account.lastname,
  email: this.account.email,
  userName: this.account.login,

  }
  this.$http.put('https://localhost:44335/api/Account/update'+this.$route.params.id, updAccount)
  .then(function(response){
  this.$router.push({path: '/', query: {alert: 'Konto zaktualizowane'}});
  });
  e.preventDefault();
  }
  e.preventDefault();
  }
  },
  created: function(){
  this.fetchAccount(this.$route.params.id);
  },
  components:{
  Alert
  }
  };
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped="">
</style>
