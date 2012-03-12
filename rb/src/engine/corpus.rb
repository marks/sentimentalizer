class Corpus

  @tokens = {}

  def entry_count
    @tokens.values.inject(0, :+)
  end

  def add document
    document.foreach { |token|
      @tokens[token] = 0 unless @tokens.has_key? token
      @tokens[token] += 1
    }
  end

  def load_from_directory directory

    Dir.glob("#{directory}/*.txt") { |entry|
      IO.foreach(entry){ |line|
        add Document.new(line)
      }
    }
  end

  def token_count token
    @tokens[token] || 0
  end
end

class Document

  def initialise content
  end
end
