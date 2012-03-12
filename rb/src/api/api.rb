require 'sinatra'
require 'json'
require "#{File.dirname(__FILE__)}/../engine/analyser"

Analyser.train_positive "#{File.dirname(__FILE__)}/../../data/positive"
Analyser.train_negative "#{File.dirname(__FILE__)}/../../data/negative"

get '/' do
  sentence = params[:sentence]

  halt 500, "Need something to compare" if sentence.nil? || sentence.empty?

  content_type :json
  Analyser.analyse(sentence).to_json
end
