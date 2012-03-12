require 'sinatra'
require 'json'
require './analyser'

Analyser.train_positive "../data/positive"
Analyser.train_negative "../data/negative"

get '/' do
  sentence = params[:sentence]
  # analyse sentence and return json
  {"test" => sentence}.to_json
end
