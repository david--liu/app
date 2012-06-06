configs ={
  :git => {
    :user => 'david--liu',
    :remotes => %w[skiplee heffay adriangonzalez travismartinjones masudio levesque],
    :repo => 'app' 
  }
}
configatron.configure_from_hash(configs)